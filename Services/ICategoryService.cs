using PFM.Commands;
using PFM.Models;

namespace PFM.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(CreateCategoryCommand createCategoryCommand);

        Task<PagedSortListItems<Category>> GetGategories(string? parentId);
    }
}
