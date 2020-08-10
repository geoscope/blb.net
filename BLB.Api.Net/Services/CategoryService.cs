
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLB.Api.Net.Interfaces;
using BLB.Domain.Net.Interfaces;
using BLB.Domain.Net.Models;
using BLB.Shared.Net.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BLB.Api.Net.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly DistributedCacheEntryOptions cacheOptions;
        private readonly IDistributedCache cache;
        private readonly AppSettings appSettings;

        public CategoryService(ICategoryRepository categoryRepository, IOptions<AppSettings> appSettings, IDistributedCache cache)
        {
            this.categoryRepository = categoryRepository;
            this.cache = cache;
            this.appSettings = appSettings.Value;
            this.cacheOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(this.appSettings.DefaultCacheMinutes));
        }

        public IEnumerable<Category> GetAllCategories(long storeId)
        {
            string jsonCategories;

            var cachedCategories = cache.GetString($"categories:{storeId}");
            if (cachedCategories != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(cachedCategories);
            }
            else
            {
                var categories = categoryRepository.GetAll(storeId);
                jsonCategories = JsonConvert.SerializeObject(categories);
                cache.SetString($"categories:{storeId}", jsonCategories, cacheOptions);

                return categories;
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(long storeId)
        {
            string jsonCategories;

            var cachedCategories = await cache.GetStringAsync($"categories:{storeId}");
            if (cachedCategories != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(cachedCategories);
            }
            else
            {
                var categories = await categoryRepository.GetAllAsync(storeId);
                jsonCategories = JsonConvert.SerializeObject(categories);
                await cache.SetStringAsync($"categories:{storeId}", jsonCategories, cacheOptions);

                return categories;
            }
        }

        public Category GetCategory(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategory = cache.GetString($"category:{storeId}:{categoryId}");
            if (cachedCategory != null)
            {
                return JsonConvert.DeserializeObject<Category>(cachedCategory);
            }
            else
            {
                var category = categoryRepository.GetSingle(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(category);
                cache.SetString($"category:{storeId}:{categoryId}", jsonCategory, cacheOptions);

                return category;
            }
        }

        public async Task<Category> GetCategoryAsync(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategory = await cache.GetStringAsync($"category:{storeId}:{categoryId}");
            if (cachedCategory != null)
            {
                return JsonConvert.DeserializeObject<Category>(cachedCategory);
            }
            else
            {
                var category = await categoryRepository.GetSingleAsync(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(category);
                await cache.SetStringAsync($"category:{storeId}:{categoryId}", jsonCategory, cacheOptions);

                return category;
            }
        }

        public IEnumerable<Category> GetCategoryWithChildren(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategories = cache.GetString($"categories:children:{storeId}");
            if (cachedCategories != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(cachedCategories);
            }
            else
            {
                var categories = categoryRepository.GetSingleWithChildren(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(categories);
                cache.SetString($"categories:children:{storeId}", jsonCategory, cacheOptions);

                return categories;
            }
        }

        public async Task<IEnumerable<Category>> GetCategoryWithChildrenAsync(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategories = await cache.GetStringAsync($"categories:children:{storeId}");
            if (cachedCategories != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(cachedCategories);
            }
            else
            {
                var categories = await categoryRepository.GetSingleWithChildrenAsync(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(categories);
                await cache.SetStringAsync($"categories:children:{storeId}", jsonCategory, cacheOptions);

                return categories;
            }
        }

        public IEnumerable<Category> GetCategoryWithParents(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategories = cache.GetString($"categories:parents:{storeId}");
            if (cachedCategories != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(cachedCategories);
            }
            else
            {
                var categories = categoryRepository.GetSingleWithParents(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(categories);
                cache.SetString($"categories:parents:{storeId}", jsonCategory, cacheOptions);

                return categories;
            }
        }

        public async Task<IEnumerable<Category>> GetCategoryWithParentsAsync(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategories = await cache.GetStringAsync($"categories:parents:{storeId}");
            if (cachedCategories != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(cachedCategories);
            }
            else
            {
                var categories = await categoryRepository.GetSingleWithParentsAsync(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(categories);
                await cache.SetStringAsync($"categories:parents:{storeId}", jsonCategory, cacheOptions);

                return categories;
            }
        }
    }
}
