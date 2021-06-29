using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Funds.Commands.AddFund
{
    public class AddFundRequest: IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public string Name { get; set; }
    }
}
