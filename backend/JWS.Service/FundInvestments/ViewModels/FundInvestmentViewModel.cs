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

        public double CapitalPrice { get; set; }
        public int Amount { get; set; }
        public double BuyFeePercent { get; set; }
        public double SellFeePercent { get; set; }

        public double? RevenuePercent { get; set; }
        public string RevenueCycle { get; set; }

        public DateTime? FollowedAt { get; set; }
        public DateTime? InvestedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public double? TakeProfitPercent { get; set; }
        public double? StopLossPercent { get; set; }
        public double? TrailingStopLossPercent { get; set; }

        public double MarketPrice { get; set; }
        public double SellPrice { get; set; }

        public double FinalProfit { get; set; }
        public double TotalCapital { get; set; }
        public double FinalProfitPercent { get; set; }
    }
}
