using System;
using System.Text;
using System.Threading.Tasks;
using BLB.Api.Net.interfaces;
using BLB.Domain.Net.Interfaces;
using BLB.Domain.Net.Models;
using BLB.Shared.Net.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BLB.Api.Net.Services
{
    public class StoreHostNameService : IStoreHostNameService
    {
        private readonly IStoreHostNameRepository hostNameRepository;
        private readonly DistributedCacheEntryOptions cacheOptions;
        private readonly IDistributedCache cache;
        private readonly AppSettings appSettings;

        public StoreHostNameService(IStoreHostNameRepository hostNameRepository, IOptions<AppSettings> appSettings, IDistributedCache cache)
        {
            this.hostNameRepository = hostNameRepository;
            this.cache = cache;
            this.appSettings = appSettings.Value;
            this.cacheOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(this.appSettings.StoreHostNameCacheMinutes));
        }

        public StoreHostName GetStoreHostName(string hostName)
        {
            string jsonStoreHostName;

            var cachedStoreHostName = cache.GetString($"storehostname:{hostName}");
            if (cachedStoreHostName != null)
            {
                return JsonConvert.DeserializeObject<StoreHostName>(cachedStoreHostName);
            }
            else
            {
                var storeHostName = hostNameRepository.GetByHostName(hostName);
                jsonStoreHostName = JsonConvert.SerializeObject(storeHostName);
                cache.SetString($"storehostname:{hostName}", jsonStoreHostName, cacheOptions);

                return storeHostName;
            }
        }

        public async Task<StoreHostName> GetStoreHostNameAsync(string hostName)
        {
            string jsonStoreHostName;

            var cachedStoreHostName = await cache.GetStringAsync($"storehostname:{hostName}");
            if (cachedStoreHostName != null)
            {
                return JsonConvert.DeserializeObject<StoreHostName>(cachedStoreHostName);
            }
            else
            {
                var storeHostName = await hostNameRepository.GetByHostNameAsync(hostName);
                jsonStoreHostName = JsonConvert.SerializeObject(storeHostName);
                await cache.SetStringAsync($"storehostname:{hostName}", jsonStoreHostName, cacheOptions);

                return storeHostName;
            }
        }
    }
}