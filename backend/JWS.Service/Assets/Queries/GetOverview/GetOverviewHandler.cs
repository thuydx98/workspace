using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.Assets.ViewModels;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Assets.Queries.GetOverview
{
    public class GetOverviewHandler : IRequestHandler<GetOverviewRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetOverviewHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(GetOverviewRequest request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue || request.UserId == Guid.Empty)
            {
                return ApiResult.Failed(HttpCode.BadRequest);
            }

            var assets = await _unitOfWork.GetRepository<AssetEntity>().GetListAsync(
                selector: n => new
                {
                    n.Amount,
                    n.Type,
                },
                predicate: n => n.UserId == request.UserId,
                cancellationToken: cancellationToken);

            var fundHistories = await _unitOfWork.GetRepository<FundHistoryEntity>().GetListAsync(
                selector: n => new
                {
                    n.Amount,
                    n.Type,
                },
                predicate: n => n.Fund.UserId == request.UserId && !n.Fund.IsDeleted,
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(new AssetOverviewViewModel
            {
                Income = assets.Where(n => n.Type == AssetType.INCOME).Sum(n => n.Amount),
                Spent = assets.Where(n => n.Type == AssetType.SPEND).Sum(n => n.Amount),
                Invest = fundHistories.Where(n => n.Type == FundHistoryType.RECHARGE).Sum(n => n.Amount) - fundHistories.Where(n => n.Type == FundHistoryType.WITHDRAW).Sum(n => n.Amount),
            });
        }
    }
}
