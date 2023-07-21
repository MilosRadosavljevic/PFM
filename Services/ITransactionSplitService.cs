using PFM.Database.Entities;

namespace PFM.Services
{
    public interface ITransactionSplitService
    {
        Task<bool> SplitTransaction(string transactionId, List<TransactionSplitEntity> splits);
    }
}
