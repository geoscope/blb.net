using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLB.Domain.Net.Interfaces
{
    public interface IStoreUserGenericRepository<T>
    {
        Task<T> GetSingleAsync(long storeId, long userId, long id);

        Task<IEnumerable<T>> GetAllAsync(long storeId, long userId);

        Task<long> AddAsync(long storeId, long userId, T record);

        Task<bool> UpdateAsync(long storeId, long userId, T record);

        Task<bool> DeleteAsync(long storeId, long userId, long id);
    }
}
