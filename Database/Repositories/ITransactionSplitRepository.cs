using PFM.Database.Entities;

namespace PFM.Database.Repositories
{
    public interface ITransactionSplitRepository
    {
        Task<bool> DeleteSplitsForTransaction(string transactionId);
        Task<bool> CreateSplits(List<TransactionSplitEntity> splits);
    }
}
