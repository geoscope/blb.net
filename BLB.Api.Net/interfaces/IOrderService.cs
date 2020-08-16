
using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Api.Net.interfaces
{
    public interface IOrderService
    {
        Task<Order> GetCurrentOrderAsync(long storeId, long userId);

        Task<Order> GetOrderAsync(long storeId, long userId, long orderId);

        Task<long> AddOrUpdateItemInOrderAsync(long storeId, long userId, OrderItem item);

        Task<bool> RemoveItemFromOrderAsync(long storeId, long userId, long orderItemId);

        Task<bool> RemoveOrderAsync(long storeId, long userId, long orderId);
    }
}
