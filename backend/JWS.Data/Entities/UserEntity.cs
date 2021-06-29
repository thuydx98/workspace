using JWS.Contracts.Entities;
using System;

namespace JWS.Data.Entities
{
    public partial class UserEntity: IBaseEntity<Guid>, ICreatedEntity, IUpdatedEntity
    {
        public Guid Id { get; set; }
        public double? Income { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
