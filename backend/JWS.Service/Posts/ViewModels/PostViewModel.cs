using JWS.Data.Entities;
using System;
using System.Linq;

namespace JWS.Service.Posts.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel(PostEntity entity)
        {
            Id = entity.Id;
            Code = entity.Code;
            Title = entity.Title;
            AvaterUrl = entity.AvaterUrl;
            Content = entity.Content;
            ParentId = entity.ParentId;
            Tags = entity.Tags.Select(n => n.Tag).ToArray();
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt ?? entity.CreatedAt;
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string AvaterUrl { get; set; }
        public string Content { get; set; }
        public Guid? ParentId { get; set; }

        public string[] Tags { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
