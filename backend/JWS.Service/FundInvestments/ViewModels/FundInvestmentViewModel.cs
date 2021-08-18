using JWS.Data.Entities;
using System;

namespace JWS.Service.FundInvestments.ViewModels
{
    public class FundInvestmentViewModel
    {
        public Guid Id { get; set; }
        public Guid FundId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string UpdateType { get; set; }
        public string Note { get; set; }

        public double? CapitalPrice { get; set; }
        public int? Amount { get; set; }
        public double? BuyFeePercent { get; set; }
        public double? SellFeePercent { get; set; }

        public double? RevenuePercent { get; set; }
        public string RevenueCycle { get; set; }

        public DateTime? FollowedAt { get; set; }
        public DateTime? InvestedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
