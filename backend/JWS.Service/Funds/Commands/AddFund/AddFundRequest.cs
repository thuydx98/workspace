using JWS.Common.ApiResponse;
using JWS.Data.Entities;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace JWS.Service.Funds.Commands.AddFund
{
    public class AddFundRequest: IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public FundType Type { get; set; }
    }
}
