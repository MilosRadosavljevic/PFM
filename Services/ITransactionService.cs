using PFM.Commands;
using PFM.Database.Entities;
using PFM.Models;

namespace PFM.Services
{
    public interface ITransactionService
    {

        Task <Transaction> CreateTransaction(CreateTransactionCommand createTransactionCommand);
        Task <PagedSortedListTransactions<Transaction>> GetTransactions(
            int page,
            int pageSize,
            SortOrder sortOrder,
            string? sortBy,
            DateTime? startDate,
            DateTime? endDate,
            TransactionKind? transactionKind);

        Task<Transaction> CategorizeTransaction(string transactionId, CategorizeTransactionCommand categorizeTransactionCommand);
    }
}
