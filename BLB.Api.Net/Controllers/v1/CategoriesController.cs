using BLB.Api.Net.Helpers;
using BLB.Api.Net.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLB.Api.Net.Controllers.v1
{
    [Authorize]
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
        public async Task<IEnumerable<Domain.Net.Models.Dto.Category>> Get()
        {
            var categoriesDto = categoryDtoHydrator.HydrateList((await categoryService.GetAllCategoriesAsync(storeId)).ToList());
            return categoriesDto;
        }

        // GET: api/v1/categories/5
        [HttpGet("{id}")]
        public async Task<Domain.Net.Models.Dto.Category> Get(long id)
        {
            var categoryDto = categoryDtoHydrator.Hydrate(await categoryService.GetCategoryAsync(storeId, id));
            return categoryDto;
        }

        // GET: api/v1/categories/1/children
        [HttpGet("{id}/children")]
        public async Task<ICollection<Domain.Net.Models.Dto.Category>> GetCategoryWithChildren(long id)
        {
            var categoriesDto = categoryDtoHydrator.HydrateList((await categoryService.GetCategoryWithChildrenAsync(storeId, id)).ToList());
            return categoriesDto;
        }

        // GET: api/v1/categories/1/parents
        [HttpGet("{id}/parents")]
        public async Task<ICollection<Domain.Net.Models.Dto.Category>> GetCategoryWithParents(long id)
        {
            var categoriesDto = categoryDtoHydrator.HydrateList((await categoryService.GetCategoryWithParentsAsync(storeId, id)).ToList());
            return categoriesDto;
        }
    }
}