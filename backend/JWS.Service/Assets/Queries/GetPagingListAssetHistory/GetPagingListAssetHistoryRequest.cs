using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Assets.Queries.GetPagingListAssetHistory
{
    public class GetPagingListAssetHistoryRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
    }
}
