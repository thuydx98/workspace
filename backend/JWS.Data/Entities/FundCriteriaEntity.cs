using JWS.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace JWS.Data.Entities
{
    public partial class FundCriteriaEntity : IBaseEntity<Guid>, ICreatedEntity, IUpdatedEntity
    {
        public FundCriteriaEntity()
        {
            InvestmentCriteries = new HashSet<FundInvestmentFundCriteriaEntity>();
        }

        public Guid Id { get; set; }
        public Guid FundId { get; set; }
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual FundEntity Fund { get; set; }

        public virtual ICollection<FundInvestmentFundCriteriaEntity> InvestmentCriteries { get; set; }
    }
}
