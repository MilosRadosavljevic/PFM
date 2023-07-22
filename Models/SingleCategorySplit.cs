using System.Text.Json.Serialization;

namespace PFM.Models
{
    public class SingleCategorySplit
    {
        [JsonIgnore] public string? TransactionId { get; set; }
        public string CategoryCode { get; set; }
        public double Amount { get; set; }
    }
}
