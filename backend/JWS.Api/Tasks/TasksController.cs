using JWS.Contracts.ApiRoutes;
using JWS.Service.Tasks.Commands.AddEditTask;
using JWS.Service.Tasks.Commands.DeleteTask;
using JWS.Service.Tasks.Queries.GetListTask;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JWS.Api.Tasks
{
    [ApiController]
    public class TasksController : BaseController
    {
        public TasksController(IMediator mediator) : base(mediator) { }

        [HttpGet(ApiRoutes.Tasks.GetList)]
        public async Task<IActionResult> GetListAsync([FromQuery] string at)
        {
            return await _mediator.Send(new GetListTaskRequest
            {
                UserId = this.UserId,
                At = at,
            });
        }

        [HttpPost(ApiRoutes.Tasks.Add)]
        public async Task<IActionResult> AddAsync(AddEditTaskRequest request)
        {
            request.Id = null;
            request.UserId = this.UserId;

            return await _mediator.Send(request);
        }

        [HttpPut(ApiRoutes.Tasks.Edit)]
        public async Task<IActionResult> AddAsync([FromRoute] Guid taskId, [FromBody] AddEditTaskRequest request)
        {
            request.Id = taskId;
            request.UserId = this.UserId;

            return await _mediator.Send(request);
        }

        [HttpDelete(ApiRoutes.Tasks.Delete)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid taskId)
        {
            return await _mediator.Send(new DeleteTaskRequest
            {
                Id = taskId,
                UserId = UserId,
            }); ;
        }
    }
}
