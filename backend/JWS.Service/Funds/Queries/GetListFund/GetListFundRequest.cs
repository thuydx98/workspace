using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Funds.Queries.GetListFund
{
    public class GetListFundRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public GetListFundRequest(Guid? userId)
        {
            UserId = userId;
        }
    }
}
