using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.FundInvestments.Queries.GetPagingListFundInvestment
{
    public class GetPagingListFundInvestmentRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public Guid FundId { get; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;

        public int? MinCriteria { get; set; }
        public string Statuses { get; set; }
    }
}
