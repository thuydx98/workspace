﻿using AutoMapper;
using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.FundInvestments.Extensions;
using JWS.Service.FundInvestments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.FundInvestments.Commands.AddEditFundInvestment
{
    public class AddEditFundInvestmentHandler : IRequestHandler<AddEditFundInvestmentRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AddEditFundInvestmentHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddEditFundInvestmentHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResult> Handle(AddEditFundInvestmentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                FundInvestmentEntity investment = null;

                if (request.InvestmentId.HasValue)
                {
                    investment = await _unitOfWork.GetRepository<FundInvestmentEntity>().SingleOrDefaultAsync(
                        predicate: n => n.Id == request.InvestmentId && n.FundId == request.FundId && n.Fund.UserId == request.UserId,
                        include: n => n.Include(i => i.InvestmentCriterias),
                        asNoTracking: false,
                        cancellationToken: cancellationToken);

                    if (investment == null)
                    {
                        return ApiResult.Failed(HttpCode.Notfound);
                    }
                }
                else
                {
                    var fund = await _unitOfWork.GetRepository<FundEntity>().SingleOrDefaultAsync(
                        predicate: n => n.Id == request.FundId && n.UserId == request.UserId,
                        cancellationToken: cancellationToken);

                    if (fund == null)
                    {
                        return ApiResult.Failed(HttpCode.Notfound);
                    }
                }


                investment ??= new FundInvestmentEntity();
                investment.FundId = request.FundId;
                investment.Name = request.Name;
                investment.Status = request.Status;
                investment.UpdateType = request.UpdateType;
                investment.FollowedAt = request.FollowedAt;
                investment.Note = request.Note;

                investment.InvestedAt = request.InvestedAt;
                investment.CapitalPrice = request.CapitalPrice ?? 0;
                investment.BuyFeePercent = request.BuyFeePercent ?? 0;
                investment.SellFeePercent = request.SellFeePercent ?? 0;

                if (request.UpdateType == FundInvestmentUpdateType.MANUAL)
                {
                    investment.Amount = request.Amount ?? 0;
                    investment.MarketPrice = request.MarketPrice ?? request.CapitalPrice ?? 0;
                    investment.TakeProfitPercent = request.TakeProfitPercent;
                    investment.StopLossPercent = request.StopLossPercent;
                    investment.TrailingStopLossPercent = request.TrailingStopLossPercent;
                }

                if (request.UpdateType == FundInvestmentUpdateType.AUTO)
                {
                    investment.Amount = 1;
                    investment.RevenuePercent = request.RevenuePercent;
                    investment.RevenueCycle = request.RevenueCycle;
                }

                if (request.Status == FundInvestmentStatus.COMPLETED)
                {
                    investment.SellPrice = request.SellPrice ?? 0;
                    investment.CompletedAt = request.CompletedAt;
                }

                investment.CalculateProfit();

                if (request.InvestmentId.HasValue)
                {
                    _unitOfWork.GetRepository<FundInvestmentFundCriteriaEntity>().Delete(investment.InvestmentCriterias);
                }

                investment.InvestmentCriterias = request.Criterias.Select(criteriaId => new FundInvestmentFundCriteriaEntity
                {
                    CriteriaId = criteriaId
                })
                .ToList();

                if (request.InvestmentId.HasValue)
                {
                    _unitOfWork.GetRepository<FundInvestmentEntity>().Update(investment);
                }
                else
                {
                    _unitOfWork.GetRepository<FundInvestmentEntity>().Insert(investment);
                }

                await _unitOfWork.CommitAsync();

                return ApiResult.Succeeded(_mapper.Map<FundInvestmentViewModel>(investment));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error at: {DateTime.UtcNow.ToString()} (UTC)");
                return ApiResult.Failed(HttpCode.InternalServerError);
            }
        }
    }
}
