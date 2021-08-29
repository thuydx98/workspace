using JWS.Contracts.Entities;
using System;

namespace JWS.Data.Entities
{
    public class PostTagEntity : IBaseEntity<Guid>, ICreatedEntity
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Tag { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual PostEntity Post { get; set; }
    }
}
