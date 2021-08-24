using JWS.Common.ApiResponse;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace JWS.Service.FundCriteria.Commands.AddEditFundCriteria
{
    public class AddEditFundCriteriaRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public Guid FundId { get; set; }

        public Guid? CriteriaId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
