using JWS.Common.ApiResponse;
using JWS.Data.Entities;
using MediatR;
using System;

namespace JWS.Service.Posts.Commands.AddEditPost
{
    public class AddEditPostRequest : IRequest<ApiResult>
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public string Title { get; set; }
        public string AvaterUrl { get; set; }
        public string Content { get; set; }
        public Guid? ParentId { get; set; }

        public string[] Tags { get; set; }
    }
}
