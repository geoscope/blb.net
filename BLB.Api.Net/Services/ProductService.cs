using System;
using System.Collections.Generic;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly DistributedCacheEntryOptions cacheOptions;
        private readonly IDistributedCache cache;
        private readonly AppSettings appSettings;

        public ProductService(IProductRepository productRepository, IOptions<AppSettings> appSettings, IDistributedCache cache)
        {
            this.productRepository = productRepository;
            this.cache = cache;
            this.appSettings = appSettings.Value;
            this.cacheOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(this.appSettings.DefaultCacheMinutes));
        }

        public IEnumerable<Product> GetProductsByCategory(long storeId, long categoryId, int page = 1, int pageSize = 25)
        {
            string jsonProducts;

            var cachedProducts = cache.GetString($"products:store-category:{storeId}-{categoryId}-{page}-{pageSize}");
            if (cachedProducts != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Product>>(cachedProducts);
            }
            else
            {
                var products = productRepository.GetProductsByCategory(storeId, categoryId, page, pageSize);
                jsonProducts = JsonConvert.SerializeObject(products);
                cache.SetString($"products:store-category:{storeId}-{categoryId}-{page}-{pageSize}", jsonProducts, cacheOptions);

                return products;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(long storeId, long categoryId, int page = 1, int pageSize = 25)
        {
            string jsonProducts;

            var cachedProducts = await cache.GetStringAsync($"products:store-category:{storeId}-{categoryId}-{page}-{pageSize}");
            if (cachedProducts != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Product>>(cachedProducts);
            }
            else
            {
                var products = await productRepository.GetProductsByCategoryAsync(storeId, categoryId, page, pageSize);
                jsonProducts = JsonConvert.SerializeObject(products);
                await cache.SetStringAsync($"products:store-category:{storeId}-{categoryId}-{page}-{pageSize}", jsonProducts, cacheOptions);

                return products;
            }
        }
    }
}