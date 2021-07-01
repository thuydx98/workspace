using System;

namespace JWS.Service.Assets.ViewModels
{
    public class AssetViewModel
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public DateTime At { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
    }
}
