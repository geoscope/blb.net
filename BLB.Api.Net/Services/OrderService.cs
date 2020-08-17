using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLB.Api.Net.interfaces;
using BLB.Domain.Net.Interfaces;
using BLB.Domain.Net.Models;
using BLB.Domain.Net.Models.Enums;

namespace BLB.Api.Net.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<long> AddOrUpdateItemInOrderAsync(long storeId, long userId, OrderItem item)
        {
            var orderId = await orderRepository.AddOrderItemAsync(storeId, userId, item);

            return orderId;
        }

        public async Task<Order> GetCurrentOrderAsync(long storeId, long userId)
        {
            var order = await orderRepository.GetOrderByStatusAsync(storeId, userId, OrderStatus.Open);

            return order;
        }


        public async Task<Order> GetOrderAsync(long storeId, long userId, long orderId)
        {
            var order = await orderRepository.GetSingleAsync(storeId, userId, orderId);

            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserAsync(long storeId, long userId)
        {
            var orders = await orderRepository.GetAllAsync(storeId, userId);

            return orders;
        }

        public async Task<bool> RemoveItemFromOrderAsync(long storeId, long userId, long orderItemId)
        {
            var result = await orderRepository.DeleteOrderItemAsync(storeId, userId, orderItemId);

            return result;
        }

        public async Task<bool> RemoveOrderAsync(long storeId, long userId, long orderId)
        {
            var result = await orderRepository.DeleteAsync(storeId, userId, orderId);

            return result;
        }
    }
}
