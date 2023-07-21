using PFM.Database.Entities;

namespace PFM.Database.Repositories
{
    public class TransactionSplitRepository : ITransactionSplitRepository
    {
        PfmDbContext _dbContext;

        public TransactionSplitRepository(PfmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateSplits(List<TransactionSplitEntity> splits)
        {
            _dbContext.TransactionSplits.AddRange(splits);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeleteSplitsForTransaction(string transactionId)
        {
            throw new NotImplementedException();
        }
    }
}
