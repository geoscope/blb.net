using System.Collections.Generic;
using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Domain.Net.Interfaces
{
    public interface IStoreHostNameRepository : IGenericRepository<StoreHostName>
    {
        StoreHostName GetByHostName(string hostName);

        Task<StoreHostName> GetByHostNameAsync(string hostName);

    }
}
