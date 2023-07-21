using Newtonsoft.Json;

namespace PFM.Database.Entities
{
    public class TransactionSplitEntity
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public int TransactionId { get; set; }

        [JsonProperty("catCode")]
        public string CatCode { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}

