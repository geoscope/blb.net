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
        private readonly ICategoryService categoryService;
        private readonly IGenericHydrator<Domain.Net.Models.Category, Domain.Net.Models.Dto.Category> categoryDtoHydrator;

        public CategoriesController(ICategoryService categoryService, IGenericHydrator<Domain.Net.Models.Category,Domain.Net.Models.Dto.Category> categoryDtoHydrator)
        {
            this.categoryService = categoryService;
            this.categoryDtoHydrator = categoryDtoHydrator;
        }

        // DELETE: api/v1/Categories/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET: api/v1/Categories
        [HttpGet]
        public IEnumerable<Domain.Net.Models.Dto.Category> Get()
        {
            var categoriesDto = categoryDtoHydrator.HydrateList(categoryService.GetAllCategories(1).ToList());
            return categoriesDto;
        }

        // GET: api/v1/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public Domain.Net.Models.Dto.Category Get(int id)
        {
            var categoryDto = categoryDtoHydrator.Hydrate(categoryService.GetCategory(1, id));
            return categoryDto;
        }

        // POST: api/v1/Categories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/v1/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}