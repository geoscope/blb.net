using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderService _orderService;
        private readonly IGenericHydrator<Domain.Net.Models.Order, Domain.Net.Models.Dto.Order> _orderDtoHydrator;
        private readonly long _storeId;
        private readonly long _userId;

        public OrdersController(IHttpContextAccessor httpContextAccessor, IOrderService orderService, IGenericHydrator<Domain.Net.Models.Order, Domain.Net.Models.Dto.Order> orderDtoHydrator)
        {
            _httpContextAccessor = httpContextAccessor;
            _orderService = orderService;
            _orderDtoHydrator = orderDtoHydrator;

            var storeIdObj = _httpContextAccessor.HttpContext.Items["storeId"];
            _storeId = long.Parse(storeIdObj.ToString());

            var userObj = _httpContextAccessor.HttpContext.Items["User"] as Domain.Net.Models.User;
            _userId = userObj?.Id ?? 0;
        }


        // GET: api/orders/current
        [HttpGet("current")]
        public async Task<Domain.Net.Models.Dto.Order> GetCurrentOrder()
        {
            var currentOrder = _orderDtoHydrator.Hydrate(await _orderService.GetCurrentOrderAsync(_storeId, _userId));
            return currentOrder;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IEnumerable<Domain.Net.Models.Dto.Order>> Get()
        {
            var orders = _orderDtoHydrator.HydrateList((await _orderService.GetOrdersByUserAsync(_storeId, _userId)).ToList());
            return orders;
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public async Task<Domain.Net.Models.Dto.Order> Get(int id)
        {
            var order = _orderDtoHydrator.Hydrate(await _orderService.GetOrderAsync(_storeId, _userId, id));

            return order;
        }

        // POST api/orders/orderitem
        [HttpPost]
        public void Post([FromBody] Domain.Net.Models.Dto.OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Domain.Net.Models.Dto.OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.RemoveOrderAsync(_storeId, _userId, id);

            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
