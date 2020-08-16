using System.Collections.Generic;
using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Api.Net.interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(long storeId, long productId);

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(long storeId, long categoryId, int page = 1, int pageSize = 25);
    }
}
