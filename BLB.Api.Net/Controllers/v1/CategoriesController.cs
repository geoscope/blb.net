using BLB.Api.Net.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BLB.Api.Net.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly long storeId;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICategoryService categoryService;
        private readonly IGenericHydrator<Domain.Net.Models.Category, Domain.Net.Models.Dto.Category> categoryDtoHydrator;

        public CategoriesController(IHttpContextAccessor httpContextAccessor, ICategoryService categoryService, IGenericHydrator<Domain.Net.Models.Category, Domain.Net.Models.Dto.Category> categoryDtoHydrator)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.categoryService = categoryService;
            this.categoryDtoHydrator = categoryDtoHydrator;

            var storeIdObj = this.httpContextAccessor.HttpContext.Items["storeId"];
            this.storeId = long.Parse(storeIdObj.ToString());
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