namespace JWS.Service.Assets.ViewModels
{
    public class AssetOverviewViewModel
    {
        public double Income { get; set; }
        public double Spent { get; set; }
        public double Invest { get; set; }
        public double Balance => this.Income - this.Spent - this.Invest;
    }
}
