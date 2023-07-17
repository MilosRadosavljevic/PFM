using PFM.Commands;
using PFM.Models;

namespace PFM.Services
{
    public interface ITransactionService
    {

        Task<Transaction> CreateTransaction(CreateTransactionCommand createTransactionCommand);
        Task<PagedSortedList<Transaction>> GetTransactions(int page, int pageSize, SortOrder sortOrder, string? sortBy);
    }
}
