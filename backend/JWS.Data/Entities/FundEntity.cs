using JWS.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace JWS.Data.Entities
{
    public partial class FundEntity : IBaseEntity<Guid>, ICreatedEntity, IUpdatedEntity
    {
        public FundEntity()
        {
            Histories = new HashSet<FundHistoryEntity>();
            Investments = new HashSet<FundInvestmentEntity>();
            Criterias = new HashSet<FundCriteriaEntity>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public FundType? Type { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<FundHistoryEntity> Histories { get; set; }
        public virtual ICollection<FundInvestmentEntity> Investments { get; set; }
        public virtual ICollection<FundCriteriaEntity> Criterias { get; set; }
    }

    public enum FundType
    {
        STOCK, SAVING
    }
}
