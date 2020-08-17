using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLB.Api.Net.Helpers;
using BLB.Api.Net.interfaces;
using BLB.Api.Net.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLB.Api.Net.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public IOrderService orderService { get; }
        private readonly IGenericHydrator<Domain.Net.Models.Order, Domain.Net.Models.Dto.Order> orderDtoHydrator;
        private readonly long storeId;

        public OrdersController(IHttpContextAccessor httpContextAccessor, IOrderService orderService, IGenericHydrator<Domain.Net.Models.Order, Domain.Net.Models.Dto.Order> orderDtoHydrator)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.orderService = orderService;
            this.orderDtoHydrator = orderDtoHydrator;

            var storeIdObj = this.httpContextAccessor.HttpContext.Items["storeId"];
            this.storeId = long.Parse(storeIdObj.ToString());
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IEnumerable<Domain.Net.Models.Dto.Order>> Get()
        {
            var orders = orderDtoHydrator.HydrateList((await this.orderService.GetOrdersByUserAsync(this.storeId, 1)).ToList());
            return orders;
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public Task<Domain.Net.Models.Dto.Order> Get(int id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
