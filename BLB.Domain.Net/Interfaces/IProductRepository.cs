﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Domain.Net.Interfaces
{
    public interface IProductRepository : IStoreGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(long storeId, long categoryId, int page, int pageSize);
    }
}
