using JWS.Data.Entities;
using System;

namespace JWS.Service.Assets.ViewModels
{
    public class AssetHistoryViewModel
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public DateTime At { get; set; }
        public string Note { get; set; }
        public AssetHistoryType Type { get; set; }
    }
}
