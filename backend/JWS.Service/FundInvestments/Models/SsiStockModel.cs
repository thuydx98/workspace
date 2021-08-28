namespace JWS.Service.FundInvestments.Models
{
    public class SsiStockReqModel
    {
        public string Status { get; set; }

        public SsiStockModel[] Data { get; set; }
    }

    public class SsiStockModel
    {
        public string ClientName { get; set; }

        public string ClientNameEn { get; set; }

        public string Code { get; set; }

        public string StockNo { get; set; }
    }
}
