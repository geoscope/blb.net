using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLB.Domain.Net.Interfaces
{
    public interface IGenericRepository<T>
    {
        T GetSingle(long id);

        Task<T> GetSingleAsync(long id);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        long Add(T record);

        Task<long> AddAsync(T record);

        bool Update(T record);

        Task<bool> UpdateAsync(T record);

        bool Delete(T record);

        Task<bool> DeleteAsync(T record);
    }
}
