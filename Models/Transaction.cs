using CsvHelper.Configuration.Attributes;

namespace PFM.Models
{
    public class Transaction
    {
        [Name("id")]
        public string TransactionId { get; set; }

        [Name("beneficiary-name")]
        public string BeneficiaryName { get; set; }

        [Name("date")]
        public DateTime Date { get; set; }

        [Name("direction")]
        public Direction Direction { get; set; }

        [Name("amount")]
        public double Amount { get; set; }

        [Name("description")]
        public string Description { get; set; }

        [Name("currency")]
        public string Currency { get; set; }

        [Name("mcc")]
        public MccCode? MccCode { get; set; }

        [Name("kind")]
        public TransactionKind Kind { get; set; }

        public string catCode { get; set; }

    }
}
