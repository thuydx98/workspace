using JWS.Common.ApiResponse;
using JWS.Data.Entities;
using MediatR;
using System;

namespace JWS.Service.FundHistories.Commands.AddFundHistory
{
    public class AddFundHistoryRequest : IRequest<ApiResult>
    {
        public Guid FundId { get; set; }
        public Guid? UserId { get; set; }
        public FundHistoryType Type { get; set; }
        public double Amount { get; set; }
        public DateTime At { get; set; }
        public string Note { get; set; }
    }
}
