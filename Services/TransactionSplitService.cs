using PFM.Database.Entities;
using PFM.Database.Repositories;

namespace PFM.Services
{
    public class TransactionSplitService : ITransactionSplitService
    {
        ITransactionSplitRepository _splitRepository;
        ITransactionRepository _transactionRepository;

        public TransactionSplitService(ITransactionSplitRepository splitRepository)
        {
            _splitRepository = splitRepository;
        }

        public async Task<bool> SplitTransaction(string transactionId, List<TransactionSplitEntity> splits)
        {
            var transaction = await _transactionRepository.GetTransactionById(transactionId);
            if (transaction == null)
            {
                return false;
            }

            await _splitRepository.CreateSplits(splits);

            return true;
        }
    }
}
