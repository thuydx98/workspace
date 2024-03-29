﻿using JWS.Common.Extensions;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.FundInvestments.Extensions;
using JWS.Service.FundInvestments.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NCrontab;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.FundInvestments.Jobs.SyncStockPrice
{
    public class SyncStockPriceJob : BackgroundService
    {
        private const string CACHE_KEY = "SyncStockPriceJob:Stocks";

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;
        private readonly CrontabSchedule _schedule;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;

        private DateTime nextRun;

        public SyncStockPriceJob(IServiceProvider serviceProvider, HttpClient httpClient, IMemoryCache memoryCache, ILogger<SyncStockPriceJob> logger)
        {
            _httpClient = httpClient;
            _memoryCache = memoryCache;
            _logger = logger;
            _serviceProvider = serviceProvider;
            _schedule = CrontabSchedule.Parse(Environment.GetEnvironmentVariable("CRON_SYNC_STOCK_PRICE"));

            nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            do
            {
                var runAt = DateTime.UtcNow;

                if (nextRun < runAt)
                {
                    await SyncStockPriceAsync(cancellationToken);

                    nextRun = _schedule.GetNextOccurrence(runAt);

                    _logger.LogInformation($"{nameof(SyncStockPriceJob)}: Task started at {runAt} (UTC) and completed in {DateTime.UtcNow - runAt}");
                }

                var nextRunInTimeSpan = (nextRun - DateTime.UtcNow).TotalMilliseconds;
                var nextRunInMiliseconds = nextRunInTimeSpan > 0 ? nextRunInTimeSpan : 1000;

                await Task.Delay((int)nextRunInMiliseconds, cancellationToken);
            }
            while (!cancellationToken.IsCancellationRequested);
        }

        private async Task SyncStockPriceAsync(CancellationToken cancellationToken)
        {
            try
            {
                using var unitOfWork = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IUnitOfWork>();

                if (!_memoryCache.TryGetValue(CACHE_KEY, out SsiStockModel[] stocks))
                {
                    var stocksResponse = await _httpClient.GetAsync<SsiStockResModel>("https://iboard.ssi.com.vn/dchart/api/1.1/defaultAllStocks");
                    stocks = stocksResponse.Data;

                    _memoryCache.Set(CACHE_KEY, stocks, DateTime.Now.AddHours(6));
                }

                var investments = await unitOfWork.GetRepository<FundInvestmentEntity>().GetListAsync(
                    predicate: n =>
                        (n.Fund.Type == FundType.STOCK) &&
                        (n.Status == FundInvestmentStatus.FOLLOWING || n.Status == FundInvestmentStatus.INVESTING),
                    asNoTracking: false,
                    cancellationToken: cancellationToken);

                if (investments.Count > 0)
                {
                    var stockIds = stocks.Join(investments, stock => stock.Code, invest => invest.Name, (stock, invest) => stock.StockNo).Distinct();

                    var pricesResponse = await _httpClient.PostAsJsonAsync<SsiGetStockRealtimeResModel>("https://gateway-iboard.ssi.com.vn/graphql", new SsiGetStockRealtimeReqModel
                    {
                        Variables = new SsiVariableModel
                        {
                            Ids = stockIds.ToArray(),
                        }
                    });

                    foreach (var investment in investments)
                    {
                        var stock = pricesResponse.Data.StockRealtimesByIds.FirstOrDefault(n => n.StockSymbol == investment.Name);
                        if (stock != null)
                        {
                            investment.MarketPrice = stock.MatchedPrice;
                            investment.HighestPrice = investment.HighestPrice < stock.MatchedPrice ? stock.MatchedPrice : investment.HighestPrice;

                            investment.CalculateProfit();
                        }
                    }

                    unitOfWork.GetRepository<FundInvestmentEntity>().Update(investments);

                    await unitOfWork.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error at: {DateTime.UtcNow.ToString()} (UTC)");
            }
        }
    }
}
