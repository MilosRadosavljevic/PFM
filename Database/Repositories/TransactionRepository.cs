using Microsoft.EntityFrameworkCore;
using PFM.Database.Entities;
using PFM.Models;

namespace PFM.Database.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        PfmDbContext _dbContext;

        public TransactionRepository(PfmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TransactionEntity> CreateTransaction(TransactionEntity newTransactionEntity)
        {
            _dbContext.Transactions.Add(newTransactionEntity);
            await _dbContext.SaveChangesAsync();
            return newTransactionEntity;
        }

        public async Task<PagedSortedListTransactions<TransactionEntity>> GetTransactions(
            int page = 1,
            int pageSize = 10,
            SortOrder sortOrder = SortOrder.Asc,
            string? sortBy = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            TransactionKind? transactionKind = null
            )
        {

            var query = _dbContext.Transactions.AsQueryable();
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling(totalCount * 1.0 / pageSize);

            if (!String.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    //case "id":
                    //    query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
                    //    break;

                    //case "name":
                    //    query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.BeneficiaryName) : query.OrderByDescending(x => x.BeneficiaryName);
                    //    break;

                    //case "date":
                    //    query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Date) : query.OrderByDescending(x => x.Date);
                    //    break;

                    //case "direction":
                    //    query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Direction) : query.OrderByDescending(x => x.Direction);
                    //    break;

                    //case "amount":
                    //    query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Amount) : query.OrderByDescending(x => x.Amount);
                    //    break;

                    //case "description":
                    //    query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Description) : query.OrderByDescending(x => x.Description);
                    //    break;

                    //case "currency":
                    //    query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Currency) : query.OrderByDescending(x => x.Currency);
                    //    break;

                    //case "mcc":
                    //    query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.MccCode) : query.OrderByDescending(x => x.MccCode);
                    //    break;

                    case "kind":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Kind) : query.OrderByDescending(x => x.Kind);
                        break;

                        //case "catCode":
                        //    query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.catCode) : query.OrderByDescending(x => x.catCode);
                        //    break;
                }
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }

            if (transactionKind.HasValue)
            {
                query = query.Where(x => x.Kind == transactionKind);
            }

            if (startDate.HasValue)
            {
                query = query.Where(x => x.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(x => x.Date <= endDate.Value);
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            var transactions = await query.ToListAsync();

            return new PagedSortedListTransactions<TransactionEntity>
            {
                TotalPages = totalPages,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                SortBy = sortBy,
                SortOrder = sortOrder,
                StartDate = startDate,
                EndDate = endDate,
                TransactionKind = transactionKind,
                Items = transactions

            };
        }

        public async Task<TransactionEntity> GetTransactionById(string transactionId)
        {
            return await _dbContext.Transactions.FirstOrDefaultAsync(x => x.Id.Equals(transactionId));
        }

        public async Task<TransactionEntity> UpdateTransaction(TransactionEntity updatedTransactionEntity)
        {
            _dbContext.Transactions.Update(updatedTransactionEntity);
            await _dbContext.SaveChangesAsync();
            return updatedTransactionEntity;
        }

        public async Task<List<TransactionEntity>> GetTransactionsByCategory(string categoryCode, DateTime? startDate, DateTime? endDate, Direction? direction)
        {
            var query = _dbContext.Transactions.AsQueryable();
            var subCategories = await _dbContext.Categories
               .Where(c => c.ParentCode == categoryCode)
               .Select(c => c.Code)
               .ToListAsync();


            //query = query.Where(x => x.catCode == categoryCode);

            query = query.Where(x => x.catCode == categoryCode || subCategories.Contains(x.catCode));

            if (startDate.HasValue)
            {
                query = query.Where(x => x.Date >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(x => x.Date <= endDate.Value);
            }
            if (direction.HasValue)
            {
                query = query.Where(x => x.Direction == direction);
            }

            var transactions = await query.ToListAsync();

            return transactions;
        }

        public async Task<List<TransactionEntity>> GetAllTransactionsForAnalytics(string? categoryCode, DateTime? startDate, DateTime? endDate, Direction? direction)
        {
            var query = _dbContext.Transactions.AsQueryable();

            if (startDate.HasValue)
            {
                query = query.Where(x => x.Date >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(x => x.Date <= endDate.Value);
            }
            if (direction.HasValue)
            {
                query = query.Where(x => x.Direction == direction);
            }

            var transactions = await query.ToListAsync();

            return transactions;
        }
    }
}
