using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Posts.Commands.DeletePost
{
    public class DeletePostRequest : IRequest<ApiResult>
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public bool IsDeleteChilren { get; set; }
    }
}
