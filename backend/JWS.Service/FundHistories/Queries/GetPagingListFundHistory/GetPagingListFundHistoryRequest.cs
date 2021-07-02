using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.FundHistories.Queries.GetPagingListFundHistory
{
    public class GetPagingListFundHistoryRequest : IRequest<ApiResult>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public Guid FundId { get; set; }
        public Guid? UserId { get; set; }
    }
}
