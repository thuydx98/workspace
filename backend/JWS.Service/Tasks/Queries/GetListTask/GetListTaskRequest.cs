using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Tasks.Queries.GetListTask
{
    public class GetListTaskRequest : IRequest<ApiResult>
    {
        public string At { get; set; }
        public Guid? UserId { get; set; }
    }
}
