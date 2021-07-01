using JWS.Contracts.Entities;
using System;

namespace JWS.Data.Entities
{
    public partial class AssetEntity : IBaseEntity<Guid>, ICreatedEntity, IUpdatedEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double Amount { get; set; }
        public DateTime At { get; set; }
        public string Note { get; set; }
        public AssetType Type { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }

    public enum AssetType
    {
        INCOME, SPEND, WITHDRAW
    }
}
