using BLB.Api.Net.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BLB.Api.Net.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        const long storeId = 1;

        private readonly ICategoryService categoryService;
        private readonly IGenericHydrator<Domain.Net.Models.Category, Domain.Net.Models.Dto.Category> categoryDtoHydrator;

        public CategoriesController(ICategoryService categoryService, IGenericHydrator<Domain.Net.Models.Category, Domain.Net.Models.Dto.Category> categoryDtoHydrator)
        {
            this.categoryService = categoryService;
            this.categoryDtoHydrator = categoryDtoHydrator;
        }

        // GET: api/v1/categories
        [HttpGet]
        public IEnumerable<Domain.Net.Models.Dto.Category> Get()
        {
            var categoriesDto = categoryDtoHydrator.HydrateList(categoryService.GetAllCategories(storeId).ToList());
            return categoriesDto;
        }

        // GET: api/v1/categories/5
        [HttpGet("{id}")]
        public Domain.Net.Models.Dto.Category Get(int id)
        {
            var categoryDto = categoryDtoHydrator.Hydrate(categoryService.GetCategory(storeId, id));
            return categoryDto;
        }

        // GET: api/v1/categories/1/children
        [HttpGet("{id}/children")]
        public ICollection<Domain.Net.Models.Dto.Category> GetCategoryWithChildren(int id)
        {
            var categoriesDto = categoryDtoHydrator.HydrateList(categoryService.GetCategoryWithChildren(storeId, id).ToList());
            return categoriesDto;
        }

        // GET: api/v1/categories/1/parents
        [HttpGet("{id}/parents")]
        public ICollection<Domain.Net.Models.Dto.Category> GetCategoryWithParents(int id)
        {
            var categoriesDto = categoryDtoHydrator.HydrateList(categoryService.GetCategoryWithParents(storeId, id).ToList());
            return categoriesDto;
        }
    }
}