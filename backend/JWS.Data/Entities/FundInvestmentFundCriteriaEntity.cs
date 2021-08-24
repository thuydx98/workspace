using JWS.Contracts.Entities;
using System;

namespace JWS.Data.Entities
{
    public partial class FundInvestmentFundCriteriaEntity : IBaseEntity<Guid>, ICreatedEntity
    {
        public Guid Id { get; set; }
        public Guid InvestmentId { get; set; }
        public Guid CriteriaId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual FundInvestmentEntity Investment { get; set; }
        public virtual FundCriteriaEntity Criteria { get; set; }
    }
}
