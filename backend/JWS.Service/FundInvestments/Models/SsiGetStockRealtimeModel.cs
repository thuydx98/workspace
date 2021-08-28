using System.Text.Json.Serialization;

namespace JWS.Service.FundInvestments.Models
{
    public class SsiVariableModel
    {
        [JsonPropertyName("ids")]
        public string[] Ids { get; set; }
    }

    public class SsiGetStockRealtimeReqModel
    {
        [JsonPropertyName("operationName")]
        public string OperationName => "stockRealtimesByIds";

        [JsonPropertyName("variables")]
        public SsiVariableModel Variables { get; set; }

        [JsonPropertyName("query")]
        public string Query => @"
            query stockRealtimesByIds($ids: [String!]) {
                stockRealtimesByIds(ids: $ids) {
                    stockNo
                    stockSymbol
                    matchedPrice
                }
            }";
    }

    public class SsiGetStockRealtimeResModel
    {
        public SsiGetStockRealtimeDataModel Data { get; set; }
    }

    public class SsiGetStockRealtimeDataModel
    {
        public SsiGetStockRealtimeModel[] StockRealtimesByIds { get; set; }
    }

    public class SsiGetStockRealtimeModel
    {
        public string StockNo { get; set; }

        public string StockSymbol { get; set; }

        public int MatchedPrice { get; set; }
    }
}
