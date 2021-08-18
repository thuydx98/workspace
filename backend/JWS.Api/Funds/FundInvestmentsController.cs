using JWS.Contracts.ApiRoutes;
using JWS.Service.FundInvestments.Commands.AddFundInvestment;
using JWS.Service.FundInvestments.Queries.GetPagingListFundInvestment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JWS.Api.Funds
{
    [ApiController]
    public class FundInvestmentsController : BaseController
    {
        public FundInvestmentsController(IMediator mediator) : base(mediator) { }

        [HttpGet(ApiRoutes.Funds.Investments.GetPagingList)]
        public async Task<IActionResult> GetListAsync([FromRoute] Guid fundId, [FromQuery] GetPagingListFundInvestmentRequest request)
        {
            request.UserId = UserId;
            request.FundId = fundId;

            return await _mediator.Send(request);
        }

        [HttpPost(ApiRoutes.Funds.Investments.Add)]
        public async Task<IActionResult> AddAsync([FromRoute] Guid fundId, [FromBody] AddFundInvestmentRequest request)
        {
            request.UserId = UserId;
            request.FundId = fundId;

            return await _mediator.Send(request);
        }
    }
}
