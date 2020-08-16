using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLB.Domain.Net.Interfaces;
using BLB.Domain.Net.Models;
using BLB.Domain.Net.Models.Enums;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BLB.Domain.Net.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly string connectionString = null;

        public OrderRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BLBConnectionString");
        }

        public Task<long> AddAsync(long storeId, long userId, Order record)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddOrderItemAsync(long storeId, long userId, OrderItem item)
        {
            // get open order id - if null create a new order

            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long storeId, long userId, long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderItemAsync(long storeId, long userId, long orderItemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync(long storeId, long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderByStatusAsync(long storeId, long userId, OrderStatus orderStatus)
        {
            string sql = "SELECT * FROM \"Orders\" o WHERE o.\"StoreId\"=@storeId AND o.\"UserId\"=@userId AND o.\"OrderStatus\"=@orderStatus AND o.\"IsDeleted\"=false;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var category = await conn.QueryAsync<Order>(sql, new { storeId, userId, orderStatus }).ConfigureAwait(false);

                return category.FirstOrDefault();
            }
        }

        public async Task<Order> GetSingleAsync(long storeId, long userId, long id)
        {
            string sql = "SELECT * FROM \"Orders\" o WHERE o.\"StoreId\"=@storeId AND o.\"UserId\"=@userId AND o.\"Id\"=@id AND o.\"IsDeleted\"=false;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var category = await conn.QueryAsync<Order>(sql, new { storeId, userId, id }).ConfigureAwait(false);

                return category.FirstOrDefault();
            }
        }

        public Task<bool> UpdateAsync(long storeId, long userId, Order record)
        {
            throw new NotImplementedException();
        }
    }
}
