using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.FundInvestments.Commands.DeleteFundInvestment
{
    public class DeleteFundInvestmentRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public Guid FundId { get; set; }
        public Guid InvestmentId { get; set; }
    }
}
