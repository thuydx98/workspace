using JWS.Contracts.Entities;
using System;

namespace JWS.Data.Entities
{
    public partial class FundInvestmentEntity : IBaseEntity<Guid>, ICreatedEntity, IUpdatedEntity
    {
        public Guid Id { get; set; }
        public Guid FundId { get; set; }
        public string Name { get; set; }
        public FundInvestmentStatus Status { get; set; }
        public FundInvestmentUpdateType UpdateType { get; set; }
        public string Note { get; set; }

        public double? CapitalPrice { get; set; }
        public int? Amount { get; set; }
        public double? BuyFeePercent { get; set; }
        public double? SellFeePercent { get; set; }

        public double? RevenuePercent { get; set; }
        public FundInvestmentRevenueCycle? RevenueCycle { get; set; }

        public DateTime? FollowedAt { get; set; }
        public DateTime? InvestedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual FundEntity Fund { get; set; }
    }

    public enum FundInvestmentStatus
    {
        FOLLOWING, INVESTING, COMPLETED
    }

    public enum FundInvestmentUpdateType
    {
        AUTO, MANUAL
    }

    public enum FundInvestmentRevenueCycle
    {
        DAILY, MONTHLY, YEARLY
    }
}
