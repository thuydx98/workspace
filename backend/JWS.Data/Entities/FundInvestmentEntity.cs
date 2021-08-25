using JWS.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace JWS.Data.Entities
{
    public partial class FundInvestmentEntity : IBaseEntity<Guid>, ICreatedEntity, IUpdatedEntity
    {
        public FundInvestmentEntity()
        {
            InvestmentCriterias = new HashSet<FundInvestmentFundCriteriaEntity>();
        }

        public Guid Id { get; set; }
        public Guid FundId { get; set; }
        public string Name { get; set; }
        public FundInvestmentStatus Status { get; set; }
        public FundInvestmentUpdateType UpdateType { get; set; }
        public string Note { get; set; }

        public double CapitalPrice { get; set; }
        public int Amount { get; set; }
        public double BuyFeePercent { get; set; }
        public double SellFeePercent { get; set; }

        public double? RevenuePercent { get; set; }
        public FundInvestmentRevenueCycle? RevenueCycle { get; set; }

        public DateTime? FollowedAt { get; set; }
        public DateTime? InvestedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public double? TakeProfitPercent { get; set; }
        public double? StopLossPercent { get; set; }
        public double? TrailingStopLossPercent { get; set; }

        public double MarketPrice { get; set; }
        public double SellPrice { get; set; }

        public double TotalCapital { get; set; }
        public double FinalProfit { get; set; }
        public double FinalProfitPercent { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual FundEntity Fund { get; set; }

        public virtual ICollection<FundInvestmentFundCriteriaEntity> InvestmentCriterias { get; set; }
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
