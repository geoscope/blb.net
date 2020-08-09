
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
            string jsonCategory;

            var cachedCategories = cache.Get($"categories:{storeId}");
            if (cachedCategories != null)
            {
                jsonCategory = Encoding.UTF8.GetString(cachedCategories);
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonCategory);
            }
            else
            {
                var categories = categoryRepository.GetAll(storeId);
                jsonCategory = JsonConvert.SerializeObject(categories);
                var encodedCategory = Encoding.UTF8.GetBytes(jsonCategory);
                cache.Set($"categories:{storeId}", encodedCategory, cacheOptions);

                return categories;
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(long storeId)
        {
            string jsonCategory;

            var cachedCategories = await cache.GetAsync($"categories:{storeId}");
            if (cachedCategories != null)
            {
                jsonCategory = Encoding.UTF8.GetString(cachedCategories);
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonCategory);
            }
            else
            {
                var categories = await categoryRepository.GetAllAsync(storeId);
                jsonCategory = JsonConvert.SerializeObject(categories);
                var encodedCategory = Encoding.UTF8.GetBytes(jsonCategory);
                await cache.SetAsync($"categories:{storeId}", encodedCategory, cacheOptions);

                return categories;
            }
        }

        public Category GetCategory(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategory = cache.Get($"category:{storeId}:{categoryId}");
            if (cachedCategory != null)
            {
                jsonCategory = Encoding.UTF8.GetString(cachedCategory);
                return JsonConvert.DeserializeObject<Category>(jsonCategory);
            }
            else
            {
                var category = categoryRepository.GetSingle(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(category);
                var encodedCategory = Encoding.UTF8.GetBytes(jsonCategory);
                cache.Set($"category:{storeId}:{categoryId}", encodedCategory, cacheOptions);

                return category;
            }
        }

        public async Task<Category> GetCategoryAsync(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategory = await cache.GetAsync($"category:{storeId}:{categoryId}");
            if (cachedCategory != null)
            {
                jsonCategory = Encoding.UTF8.GetString(cachedCategory);
                return JsonConvert.DeserializeObject<Category>(jsonCategory);
            }
            else
            {
                var category = await categoryRepository.GetSingleAsync(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(category);
                var encodedCategory = Encoding.UTF8.GetBytes(jsonCategory);
                await cache.SetAsync($"category:{storeId}:{categoryId}", encodedCategory, cacheOptions);

                return category;
            }
        }

        public IEnumerable<Category> GetCategoryWithChildren(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategories = cache.Get($"categories:children:{storeId}");
            if (cachedCategories != null)
            {
                jsonCategory = Encoding.UTF8.GetString(cachedCategories);
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonCategory);
            }
            else
            {
                var categories = categoryRepository.GetSingleWithChildren(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(categories);
                var encodedCategory = Encoding.UTF8.GetBytes(jsonCategory);
                cache.Set($"categories:children:{storeId}", encodedCategory, cacheOptions);

                return categories;
            }
        }

        public async Task<IEnumerable<Category>> GetCategoryWithChildrenAsync(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategories = await cache.GetAsync($"categories:children:{storeId}");
            if (cachedCategories != null)
            {
                jsonCategory = Encoding.UTF8.GetString(cachedCategories);
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonCategory);
            }
            else
            {
                var categories = await categoryRepository.GetSingleWithChildrenAsync(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(categories);
                var encodedCategory = Encoding.UTF8.GetBytes(jsonCategory);
                await cache.SetAsync($"categories:children:{storeId}", encodedCategory, cacheOptions);

                return categories;
            }
        }

        public IEnumerable<Category> GetCategoryWithParents(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategories = cache.Get($"categories:parents:{storeId}");
            if (cachedCategories != null)
            {
                jsonCategory = Encoding.UTF8.GetString(cachedCategories);
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonCategory);
            }
            else
            {
                var categories = categoryRepository.GetSingleWithParents(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(categories);
                var encodedCategory = Encoding.UTF8.GetBytes(jsonCategory);
                cache.Set($"categories:parents:{storeId}", encodedCategory, cacheOptions);

                return categories;
            }
        }

        public async Task<IEnumerable<Category>> GetCategoryWithParentsAsync(long storeId, long categoryId)
        {
            string jsonCategory;

            var cachedCategories = await cache.GetAsync($"categories:parents:{storeId}");
            if (cachedCategories != null)
            {
                jsonCategory = Encoding.UTF8.GetString(cachedCategories);
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonCategory);
            }
            else
            {
                var categories = await categoryRepository.GetSingleWithParentsAsync(storeId, categoryId);
                jsonCategory = JsonConvert.SerializeObject(categories);
                var encodedCategory = Encoding.UTF8.GetBytes(jsonCategory);
                await cache.SetAsync($"categories:parents:{storeId}", encodedCategory, cacheOptions);

                return categories;
            }
        }
    }
}
