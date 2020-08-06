
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
