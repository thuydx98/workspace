using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Assets.Queries.GetPagingListAsset
{
    public class GetPagingListAssetRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public int Size { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
