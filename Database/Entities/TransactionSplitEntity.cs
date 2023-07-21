namespace PFM.Database.Entities
{
    public class TransactionSplitEntity
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public string CategoryCode { get; set; }
        public double Amount { get; set; }
    }
}
