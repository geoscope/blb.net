
using System.Collections.Generic;
using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Api.Net.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(long storeId);

        Task<IEnumerable<Category>> GetCategoryWithChildrenAsync(long storeId, long categoryId);

        Task<IEnumerable<Category>> GetCategoryWithParentsAsync(long storeId, long categoryId);

        Task<Category> GetCategoryAsync(long storeId, long categoryId);
    }
}
