using JWS.Contracts.ApiRoutes;
using JWS.Service.Funds.Commands.AddFund;
using JWS.Service.Funds.Commands.DeleteFund;
using JWS.Service.Funds.Commands.UpdateFund;
using JWS.Service.Funds.Queries.GetListFund;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JWS.Api.Funds
{
    [ApiController]
    public class FundsController : BaseController
    {
        public FundsController(IMediator mediator) : base(mediator) { }

        [HttpGet(ApiRoutes.Funds.GetList)]
        public async Task<IActionResult> GetPagingListAsync()
        {
            return await _mediator.Send(new GetListFundRequest(this.UserId));
        }

        [HttpPost(ApiRoutes.Funds.Add)]
        public async Task<IActionResult> AddAsync(AddFundRequest request)
        {
            request.UserId = this.UserId;
            return await _mediator.Send(request);
        }

        [HttpPut(ApiRoutes.Funds.Update)]
        public async Task<IActionResult> UpdateAsync(Guid fundId, UpdateFundRequest request)
        {
            request.UserId = this.UserId;
            request.FundId = fundId;

            return await _mediator.Send(request);
        }

        [HttpDelete(ApiRoutes.Funds.Delete)]
        public async Task<IActionResult> DeleteAsync(Guid fundId)
        {
            var request = new DeleteFundRequest
            {
                UserId = this.UserId,
                FundId = fundId,
            };

            return await _mediator.Send(request);
        }
    }
}
