using System.Text.Json.Serialization;

namespace PFM.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; }

        public string BeneficiaryName { get; set; }

        public DateTime Date { get; set; }

        public Direction Direction { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }

        public string Currency { get; set; }

        public MccCode? MccCode { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TransactionKind Kind { get; set; }

        public string? catCode { get; set; }

        public List<SingleCategorySplit>? Splits { get; set; }

    }
}
