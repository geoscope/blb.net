using System.Threading.Tasks;
using BLB.Domain.Net.Models;
using BLB.Domain.Net.Models.Enums;

namespace BLB.Domain.Net.Interfaces
{
    public interface IOrderRepository : IStoreUserGenericRepository<Order>
    {
        Task<Order> GetOrderByStatusAsync(long storeId, long userId, OrderStatus orderStatus);

        Task<long> AddOrderItemAsync(long storeId, long userId, OrderItem item);

        Task<bool> DeleteOrderItemAsync(long storeId, long userId, long orderItemId);
    }
}
