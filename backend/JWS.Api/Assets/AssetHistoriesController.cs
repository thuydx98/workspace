using JWS.Contracts.ApiRoutes;
using JWS.Service.Assets.Queries.GetPagingListAssetHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JWS.Api.Assets
{
    [ApiController]
    public class AssetHistoriesController : BaseController
    {
        public AssetHistoriesController(IMediator mediator) : base(mediator) { }

        [HttpGet(ApiRoutes.AssetHistories.GetPagingList)]
        public async Task<IActionResult> GetPagingListAsync([FromQuery] GetPagingListAssetHistoryRequest request)
        {
            request.UserId = this.UserId;
            return await _mediator.Send(request);
        }
    }
}
