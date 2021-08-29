using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Posts.Queries.GetPostById
{
    public class GetPostByIdRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
