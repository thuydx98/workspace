using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Tasks.Commands.AddEditTask
{
    public class AddEditTaskRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }

        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string At { get; set; }
        public bool IsPriority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
