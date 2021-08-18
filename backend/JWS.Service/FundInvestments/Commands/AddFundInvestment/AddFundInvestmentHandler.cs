using AutoMapper;
using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.FundInvestments.Commands.AddFundInvestment
{
    public class AddFundInvestmentHandler : IRequestHandler<AddFundInvestmentRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AddFundInvestmentHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddFundInvestmentHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResult> Handle(AddFundInvestmentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var fund = await _unitOfWork.GetRepository<FundEntity>().SingleOrDefaultAsync(
                    predicate: n => n.Id == request.FundId && n.UserId == request.UserId,
                    cancellationToken: cancellationToken);

                if (fund == null)
                {
                    return ApiResult.Failed(HttpCode.Notfound);
                }

                var investment = new FundInvestmentEntity
                {
                    Id = Guid.NewGuid(),
                    FundId = request.FundId,
                    Name = request.Name,
                    Status = request.Status,
                    UpdateType = request.UpdateType,
                    Note = request.Note,

                    CapitalPrice = request.CapitalPrice,
                    Amount = request.Amount,
                    BuyFeePercent = request.BuyFeePercent,
                    SellFeePercent = request.SellFeePercent,

                    RevenuePercent = request.RevenuePercent,
                    RevenueCycle = request.RevenueCycle,

                    FollowedAt = request.Status == FundInvestmentStatus.FOLLOWING ? request.At : null,
                    InvestedAt = request.Status == FundInvestmentStatus.INVESTING ? request.At : null,
                    CompletedAt = request.Status == FundInvestmentStatus.COMPLETED ? request.At : null,
                };

                await _unitOfWork.GetRepository<FundInvestmentEntity>().InsertAsync(investment);
                await _unitOfWork.CommitAsync();

                return ApiResult.Succeeded(_mapper.Map<FundInvestmentEntity>(investment));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return ApiResult.Failed(HttpCode.InternalServerError);
            }
        }
    }
}
