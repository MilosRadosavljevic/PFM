using Microsoft.AspNetCore.Mvc;
using PFM.Database.Entities;
using PFM.Models;

namespace PFM.Database.Repositories
{
    public interface ITransactionRepository
    {
        Task<TransactionEntity> GetTransactionById(string transactionId);
        Task<TransactionEntity> CreateTransaction(TransactionEntity transactionEntity);
        Task<PagedSortedList<TransactionEntity>> GetProducts(int pageSize = 20,  int page = 1, SortOrder sortOrder = SortOrder.Asc, string? sortby = null);

    }
}
