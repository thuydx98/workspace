using JWS.Contracts.ApiRoutes;
using JWS.Service.Assets.Commands.AddAsset;
using JWS.Service.Assets.Queries.GetPagingListAsset;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JWS.Api.Assets
{
    [ApiController]
    public class AssetsController : BaseController
    {
        public AssetsController(IMediator mediator) : base(mediator) { }

        [HttpGet(ApiRoutes.Assets.GetPagingList)]
        public async Task<IActionResult> GetPagingListAsync([FromQuery] GetPagingListAssetRequest request)
        {
            request.UserId = this.UserId;
            return await _mediator.Send(request);
        }

        [HttpPost(ApiRoutes.Assets.Add)]
        public async Task<IActionResult> AddAsync(AddAssetRequest request)
        {
            request.UserId = this.UserId;
            return await _mediator.Send(request);
        }
    }
}
