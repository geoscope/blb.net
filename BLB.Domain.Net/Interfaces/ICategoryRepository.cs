using System.Collections.Generic;
using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Domain.Net.Interfaces
{
    public interface ICategoryRepository : IStoreGenericRepository<Category>
    {
        IEnumerable<Category> GetSingleWithChildren(long storeId, long categoryId);

        Task<IEnumerable<Category>> GetSingleWithChildrenAsync(long storeId, long categoryId);

        IEnumerable<Category> GetSingleWithParents(long storeId, long categoryId);

        Task<IEnumerable<Category>> GetSingleWithParentsAsync(long storeId, long categoryId);
    }
}
