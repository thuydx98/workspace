using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Funds.Queries.GetFund
{
    public class GetFundRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public Guid FundId { get; set; }
    }
}
