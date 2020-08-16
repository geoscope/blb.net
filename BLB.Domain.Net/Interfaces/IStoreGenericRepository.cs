using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLB.Domain.Net.Interfaces
{
    public interface IStoreGenericRepository<T>
    {
        Task<T> GetSingleAsync(long storeId, long id);

        Task<IEnumerable<T>> GetAllAsync(long storeId);

        Task<long> AddAsync(long storeId, T record);

        Task<bool> UpdateAsync(long storeId, T record);

        Task<bool> DeleteAsync(long storeId, T record);
    }
}
