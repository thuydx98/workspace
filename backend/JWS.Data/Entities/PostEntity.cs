using JWS.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace JWS.Data.Entities
{
    public partial class PostEntity : IBaseEntity<Guid>, ICreatedEntity, IUpdatedEntity
    {
        public PostEntity()
        {
            Children = new HashSet<PostEntity>();
            Tags = new HashSet<PostTagEntity>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string AvaterUrl { get; set; }
        public string Content { get; set; }
        public Guid? ParentId { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual PostEntity Parent { get; set; }
        public virtual ICollection<PostEntity> Children { get; set; }
        public virtual ICollection<PostTagEntity> Tags { get; set; }
    }
}
