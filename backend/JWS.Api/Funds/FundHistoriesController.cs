using JWS.Contracts.ApiRoutes;
using JWS.Service.FundHistories.Commands.AddFundHistory;
using JWS.Service.FundHistories.Queries.GetPagingListFundHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JWS.Api.Funds
{
    [ApiController]
    public class FundHistoriesController : BaseController
    {
        public FundHistoriesController(IMediator mediator) : base(mediator) { }

        [HttpGet(ApiRoutes.Funds.Histories.GetList)]
        public async Task<IActionResult> GetPagingListAsync(Guid fundId, [FromQuery] GetPagingListFundHistoryRequest request)
        {
            request.FundId = fundId;
            request.UserId = this.UserId;
            return await _mediator.Send(request);
        }

        [HttpPost(ApiRoutes.Funds.Histories.Add)]
        public async Task<IActionResult> AddAsync(Guid fundId, AddFundHistoryRequest request)
        {
            request.FundId = fundId;
            request.UserId = this.UserId;
            return await _mediator.Send(request);
        }
    }
}
