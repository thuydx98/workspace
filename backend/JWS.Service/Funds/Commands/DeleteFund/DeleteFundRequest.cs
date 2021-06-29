using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Funds.Commands.DeleteFund
{
    public class DeleteFundRequest : IRequest<ApiResult>
    {
        public Guid FundId { get; set; }
        public Guid? UserId { get; set; }
    }
}
