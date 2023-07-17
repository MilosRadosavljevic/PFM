﻿using Microsoft.EntityFrameworkCore;
using PFM.Database.Entities;
using PFM.Models;

namespace PFM.Database.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        CategoryDbContext _dbContext;

        public CategoryRepository(CategoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<TransactionEntity> CreateTransaction(TransactionEntity newTransactionEntity)
        //{
        //    _dbContext.Transactions.Add(newTransactionEntity);
        //    await _dbContext.SaveChangesAsync();
        //    return newTransactionEntity;
        //}

        public async Task<PagedSortedList<CategoryEntity>> GetCategories(int pageSize = 20, int page = 1, SortOrder sortOrder = SortOrder.Asc, string? sortBy = null)
        {
            var query = _dbContext.Categories.AsQueryable();
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling(totalCount * 1.0 /pageSize);

            if (!String.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "code":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Code) : query.OrderByDescending(x => x.Code);
                        break;

                    //category code?
                    //case "date":
                    //    query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Date) : query.OrderByDescending(x => x.Date);
                    //    break;
                }
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var categories = await query.ToListAsync();

            return new PagedSortedList<CategoryEntity>
            {
                // da li je potrebno ovo?
                //TotalPages = totalPages,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                SortBy = sortBy,
                SortOrder = sortOrder,
                Items = categories,


            };
        }
    }
}
