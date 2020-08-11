using System.Collections.Generic;
using System.Linq;
using BLB.Api.Net.Helpers;
using BLB.Api.Net.interfaces;
using BLB.Api.Net.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLB.Api.Net.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly long storeId;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IProductService productService;
        private readonly IGenericHydrator<Domain.Net.Models.Product, Domain.Net.Models.Dto.Product> productDtoHydrator;

        public ProductsController(IHttpContextAccessor httpContextAccessor, IProductService productService, IGenericHydrator<Domain.Net.Models.Product, Domain.Net.Models.Dto.Product> productDtoHydrator)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.productService = productService;
            this.productDtoHydrator = productDtoHydrator;

            var storeIdObj = this.httpContextAccessor.HttpContext.Items["storeId"];
            this.storeId = long.Parse(storeIdObj.ToString());
        }

        // GET: api/v1/products/5
        [HttpGet("category/{categoryId}")]
        public IEnumerable<Domain.Net.Models.Dto.Product> Get(long categoryId, [FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var productsDto = productDtoHydrator.HydrateList(productService.GetProductsByCategory(storeId, categoryId, page, pageSize).ToList());
            return productsDto;
        }

    }
}