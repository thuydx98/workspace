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

namespace JWS.Service.Assets.Queries.GetPagingListAsset
{
    public class GetPagingListAssetHandler : IRequestHandler<GetPagingListAssetRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPagingListAssetHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(GetPagingListAssetRequest request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue || request.UserId == Guid.Empty)
            {
                return ApiResult.Failed(HttpCode.BadRequest);
            }

            var assets = await _unitOfWork.GetRepository<AssetEntity>().GetPagingListAsync(
                selector: n => new AssetViewModel
                {
                    Id = n.Id,
                    Type = n.Type.ToString(),
                    Amount = n.Amount,
                    At = n.At,
                    Note = n.Note,
                },
                predicate: n => n.UserId == request.UserId,
                orderBy: n => n.OrderByDescending(o => o.At),
                page: request.Page,
                size: request.Size,
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(assets);
        }
    }
}
