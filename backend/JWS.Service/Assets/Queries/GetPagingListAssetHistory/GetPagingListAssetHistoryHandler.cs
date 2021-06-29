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

namespace JWS.Service.Assets.Queries.GetPagingListAssetHistory
{
    public class GetPagingListAssetHistoryHandler : IRequestHandler<GetPagingListAssetHistoryRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPagingListAssetHistoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(GetPagingListAssetHistoryRequest request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue || request.UserId == Guid.Empty)
            {
                return ApiResult.Failed(HttpCode.BadRequest);
            }

            var assets = await _unitOfWork.GetRepository<AssetHistoryEntity>().GetPagingListAsync(
                selector: n => new AssetHistoryViewModel
                {
                    Id = n.Id,
                    Type = n.Type,
                    Amount = n.Amount,
                    At = n.At,
                    Note = n.Note,
                },
                orderBy: n => n.OrderByDescending(o => o.At),
                page: request.Page,
                size: request.Size,
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(assets);
        }
    }
}
