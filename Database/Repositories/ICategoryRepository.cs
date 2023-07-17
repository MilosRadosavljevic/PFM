using Microsoft.AspNetCore.Mvc;
using PFM.Database.Entities;
using PFM.Models;

namespace PFM.Database.Repositories
{
    public interface ICategoryRepository
    {
        Task<PagedSortedList<CategoryEntity>> GetCategories(int pageSize = 20,  int page = 1, SortOrder sortOrder = SortOrder.Asc, string? sortby = null);
    }
}
