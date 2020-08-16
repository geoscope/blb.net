using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Domain.Net.Interfaces
{
    public interface IStoreHostNameRepository : IGenericRepository<StoreHostName>
    {
        Task<StoreHostName> GetByHostNameAsync(string hostName);

    }
}
