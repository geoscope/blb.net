using System.Collections.Generic;
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
        private readonly object orderDtoHydrator;
        private readonly long storeId;

        public OrdersController(IHttpContextAccessor httpContextAccessor, IOrderService orderService, IGenericHydrator<Domain.Net.Models.Order, Domain.Net.Models.Dto.Order> orderDtoHydrator)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.orderService = orderService;
            this.orderDtoHydrator = orderDtoHydrator;

            var storeIdObj = this.httpContextAccessor.HttpContext.Items["storeId"];
            this.storeId = long.Parse(storeIdObj.ToString());
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
