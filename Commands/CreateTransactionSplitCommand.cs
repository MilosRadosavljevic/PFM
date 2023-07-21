namespace PFM.Commands
{
    public class CreateTransactionSplitCommand
    {
        public int SplitId { get; set; }

        public int TransactionId { get; set; }

        public string CatCode { get; set; }

        public double Amount { get; set; }

    }
}
