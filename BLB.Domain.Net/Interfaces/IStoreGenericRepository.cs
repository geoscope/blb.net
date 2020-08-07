using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLB.Domain.Net.Interfaces
{
    public interface IStoreGenericRepository<T>
    {
        T GetSingle(long storeId, long id);

        Task<T> GetSingleAsync(long storeId, long id);

        IEnumerable<T> GetAll(long storeId);

        Task<IEnumerable<T>> GetAllAsync(long storeId);

        long Add(long storeId, T record);

        Task<long> AddAsync(long storeId, T record);

        bool Update(long storeId, T record);

        Task<bool> UpdateAsync(long storeId, T record);

        bool Delete(long storeId, T record);

        Task<bool> DeleteAsync(long storeId, T record);
    }
}