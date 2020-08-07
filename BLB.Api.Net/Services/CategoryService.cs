
using System.Collections.Generic;
using System.Threading.Tasks;
using BLB.Api.Net.Interfaces;
using BLB.Domain.Net.Interfaces;
using BLB.Domain.Net.Models;

namespace BLB.Api.Net.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllCategories(long storeId)
        {
            return categoryRepository.GetAll(storeId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(long storeId)
        {
            return await categoryRepository.GetAllAsync(storeId);
        }

        public Category GetCategory(long storeId, long categoryId)
        {
            return categoryRepository.GetSingle(storeId, categoryId);
        }

        public async Task<Category> GetCategoryAsync(long storeId, long categoryId)
        {
            return await categoryRepository.GetSingleAsync(storeId, categoryId);
        }

        public IEnumerable<Category> GetCategoryWithChildren(long storeId, long categoryId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategoryWithChildrenAsync(long storeId, long categoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}
