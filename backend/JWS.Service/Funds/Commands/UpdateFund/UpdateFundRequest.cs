using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Funds.Commands.UpdateFund
{
    public class UpdateFundRequest : IRequest<ApiResult>
    {
        public Guid FundId { get; set; }
        public Guid? UserId { get; set; }
        public string Name { get; set; }
    }
}
