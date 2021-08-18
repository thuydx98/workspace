using JWS.Common.ApiResponse;
using JWS.Data.Entities;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace JWS.Service.FundInvestments.Commands.AddFundInvestment
{
    public class AddFundInvestmentRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
        public Guid FundId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public FundInvestmentStatus Status { get; set; }
        [Required]
        public FundInvestmentUpdateType UpdateType { get; set; }
        [Required]
        public DateTime At { get; set; }

        public string Note { get; set; }

        public double? CapitalPrice { get; set; }
        public int? Amount { get; set; }
        public double? BuyFeePercent { get; set; }
        public double? SellFeePercent { get; set; }

        public double? RevenuePercent { get; set; }
        public FundInvestmentRevenueCycle? RevenueCycle { get; set; }
    }
}
