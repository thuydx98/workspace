using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Posts.Queries.GetPostsByUserId
{
    public class GetPostsByUserIdRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
    }
}
