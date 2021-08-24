using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.FundCriteria.Commands.DeleteFundCriteria
{
    public class DeleteFundCriteriaRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public Guid FundId { get; set; }
        public Guid CriteriaId { get; set; }
    }
}
