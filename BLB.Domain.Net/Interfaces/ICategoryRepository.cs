using System.Collections.Generic;
using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Domain.Net.Interfaces
{
    public interface ICategoryRepository : IStoreGenericRepository<Category>
    {
        IEnumerable<Category> GetSingleWithChildren(long storeId, long parentCategoryId);

        Task<IEnumerable<Category>> GetSingleWithChildrenAsync(long storeId, long parentCategoryId);
    }
}
