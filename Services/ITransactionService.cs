using PFM.Commands;
using PFM.Models;

namespace PFM.Services
{
    public interface ITransactionService
    {

        Task<Transaction> CreateTransaction(CreateTransactionCommand createTransactionCommand);
        Task<PagedSortedListTransactions<Transaction>> GetTransactions(
            int page,
            int pageSize,
            SortOrder sortOrder,
            string? sortBy,
            DateTime? startDate,
            DateTime? endDate,
            TransactionKind? transactionKind);

        Task<Transaction> CategorizeTransaction(string transactionId, CategorizeTransactionCommand categorizeTransactionCommand);

        Task<bool> CheckIfTransactionExistsAsync(string transactionId);

        Task<TransactionWithSplits> CreateTransactionSplit(string transactionId, SplitTransactionCommand splitTransactionCommand);


    }
}