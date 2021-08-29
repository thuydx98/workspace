using JWS.Contracts.ApiRoutes;
using JWS.Service.Posts.Commands.AddEditPost;
using JWS.Service.Posts.Commands.DeletePost;
using JWS.Service.Posts.Queries.GetPostById;
using JWS.Service.Posts.Queries.GetPostsByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JWS.Api.Posts
{
    [ApiController]
    public class PostsController : BaseController
    {
        public PostsController(IMediator mediator) : base(mediator) { }

        [HttpGet(ApiRoutes.Posts.GetList)]
        public async Task<IActionResult> GetListAsync()
        {
            return await _mediator.Send(new GetPostsByUserIdRequest
            {
                UserId = this.UserId,
            });
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> GetListAsync([FromRoute] Guid postId)
        {
            return await _mediator.Send(new GetPostByIdRequest
            {
                UserId = this.UserId,
                PostId = postId,
            });
        }

        [HttpPost(ApiRoutes.Posts.Add)]
        public async Task<IActionResult> AddAsync(AddEditPostRequest request)
        {
            request.Id = null;
            request.UserId = this.UserId;

            return await _mediator.Send(request);
        }

        [HttpPut(ApiRoutes.Posts.Edit)]
        public async Task<IActionResult> AddAsync([FromRoute] Guid postId, [FromBody] AddEditPostRequest request)
        {
            request.Id = postId;
            request.UserId = this.UserId;

            return await _mediator.Send(request);
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid postId, [FromQuery] bool isDeleteChilren)
        {
            return await _mediator.Send(new DeletePostRequest
            {
                Id = postId,
                UserId = UserId,
                IsDeleteChilren = isDeleteChilren,
            }); ;
        }
    }
}
