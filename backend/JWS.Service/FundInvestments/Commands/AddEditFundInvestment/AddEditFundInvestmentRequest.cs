using JWS.Common.ApiResponse;
using JWS.Data.Entities;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace JWS.Service.FundInvestments.Commands.AddEditFundInvestment
{
    public class AddEditFundInvestmentRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public Guid FundId { get; set; }

        #region Fund Information
        public Guid? InvestmentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public FundInvestmentStatus Status { get; set; }
        [Required]
        public FundInvestmentUpdateType UpdateType { get; set; }
        public DateTime? FollowedAt { get; set; }
        public string Note { get; set; }

        public double? CapitalPrice { get; set; }
        public DateTime? InvestedAt { get; set; }
        #endregion


        #region UpdateType == MANUAL
        public int? Amount { get; set; }
        public double? MarketPrice { get; set; }

        public double? TakeProfitPercent { get; set; }
        public double? StopLossPercent { get; set; }
        public double? TrailingStopLossPercent { get; set; }

        public double? BuyFeePercent { get; set; }
        public double? SellFeePercent { get; set; }
        public double? SellPrice { get; set; }
        public DateTime? CompletedAt { get; set; }
        #endregion

        #region UpdateType == AUTO
        public double? RevenuePercent { get; set; }
        public FundInvestmentRevenueCycle? RevenueCycle { get; set; }
        #endregion
    }
}
