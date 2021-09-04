using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Tasks.Commands.DeleteTask
{
    public class DeleteTaskRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }

        public Guid? Id { get; set; }
    }
}
