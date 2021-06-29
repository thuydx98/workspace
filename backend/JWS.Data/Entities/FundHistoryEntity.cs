using JWS.Contracts.Entities;
using System;

namespace JWS.Data.Entities
{
    public partial class FundHistoryEntity : IBaseEntity<Guid>, ICreatedEntity, IUpdatedEntity
    {
        public Guid Id { get; set; }
        public Guid FundId { get; set; }
        public FundHistoryType Type { get; set; }
        public double Amount { get; set; }
        public DateTime At { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual FundEntity Fund { get; set; }
    }

    public enum FundHistoryType
    {
        RECHARGE, WITHDRAW
    }
}
