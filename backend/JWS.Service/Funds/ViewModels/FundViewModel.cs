using JWS.Service.FundCriteria.ViewModels;
using System;

namespace JWS.Service.Funds.ViewModels
{
    public class FundViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public double Capital { get; set; }
        public double Reality { get; set; }

        public double Invest { get; set; }
        public double RealityInvest { get; set; }

        public double Balance => this.Reality - this.Invest;

        public FundCriteriaViewModel[] Criterias { get; set; }
    }
}
