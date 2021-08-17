using JWS.Data.Entities;
using System;

namespace JWS.Service.FundHistories.ViewModels
{
    public class FundHistoryViewModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
        public DateTime At { get; set; }
    }
}
