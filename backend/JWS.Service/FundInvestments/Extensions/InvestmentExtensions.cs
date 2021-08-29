using JWS.Data.Entities;

namespace JWS.Service.FundInvestments.Extensions
{
    public static class InvestmentExtensions
    {
        public static void CalculateProfit(this FundInvestmentEntity investment)
        {
            if (investment.UpdateType == FundInvestmentUpdateType.MANUAL)
            {
                if (investment.Status == FundInvestmentStatus.COMPLETED)
                {
                    investment.TotalCapital =
                        investment.CapitalPrice * investment.Amount +
                        investment.BuyFeePercent / 100 * investment.CapitalPrice * investment.Amount;

                    var totalSellFeeAndCapital =
                        investment.TotalCapital +
                        investment.SellFeePercent / 100 * investment.SellPrice * investment.Amount;

                    investment.FinalProfit = investment.SellPrice * investment.Amount - totalSellFeeAndCapital;
                    investment.FinalProfitPercent = investment.FinalProfit / totalSellFeeAndCapital * 100;
                }

                if (investment.Status == FundInvestmentStatus.INVESTING)
                {
                    investment.TotalCapital =
                        investment.CapitalPrice * investment.Amount +
                        investment.BuyFeePercent / 100 * investment.CapitalPrice * investment.Amount;

                    var totalSellFeeAndCapital =
                        investment.TotalCapital +
                        investment.SellFeePercent / 100 * investment.MarketPrice * investment.Amount;

                    investment.FinalProfit = investment.MarketPrice * investment.Amount - totalSellFeeAndCapital;
                    investment.FinalProfitPercent = investment.FinalProfit / totalSellFeeAndCapital * 100;
                }
            }
        }
    }
}
