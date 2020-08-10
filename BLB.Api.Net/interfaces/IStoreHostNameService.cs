using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Api.Net.interfaces
{
    public interface IStoreHostNameService
    {
        StoreHostName GetStoreHostName(string hostName);

        Task<StoreHostName> GetStoreHostNameAsync(string hostName);
    }
}