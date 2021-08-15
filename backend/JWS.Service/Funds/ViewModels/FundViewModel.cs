using System;

namespace JWS.Service.Funds.ViewModels
{
    public class FundViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Total { get; set; }
        public double Invest { get; set; }
        public double Balance => this.Total - this.Invest;
    }
}
