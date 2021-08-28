using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.FundInvestments.Commands.DeleteFundInvestment
{
    public class DeleteFundInvestmentHandler : IRequestHandler<DeleteFundInvestmentRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeleteFundInvestmentHandler(IUnitOfWork unitOfWork, ILogger<DeleteFundInvestmentHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResult> Handle(DeleteFundInvestmentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var investment = await _unitOfWork.GetRepository<FundInvestmentEntity>().SingleOrDefaultAsync(
                        predicate: n =>
                            n.Id == request.InvestmentId &&
                            n.FundId == request.FundId &&
                            n.Fund.UserId == request.UserId &&
                            n.Status == FundInvestmentStatus.FOLLOWING,
                        asNoTracking: false,
                        cancellationToken: cancellationToken);

                if (investment == null)
                {
                    return ApiResult.Failed(HttpCode.Notfound);
                }

                _unitOfWork.GetRepository<FundInvestmentEntity>().Delete(investment);

                await _unitOfWork.CommitAsync();

                return ApiResult.Succeeded();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error at: {DateTime.UtcNow.ToString()} (UTC)");
                return ApiResult.Failed(HttpCode.InternalServerError);
            }
        }
    }
}
