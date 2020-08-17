using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLB.Domain.Net.Interfaces;
using BLB.Domain.Net.Models;
using BLB.Domain.Net.Models.Enums;
using Dapper;
using Dapper.Contrib.Extensions;
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

        public async Task<long> AddOrderItemAsync(long storeId, long userId, OrderItem item)
        {
            if (item == null)
                throw new ArgumentException("Invalid order item");

            var order = await GetOrderByStatusAsync(storeId, userId, OrderStatus.Open).ConfigureAwait(false);

            long orderId;
            if (order != null)
            {
                orderId = order.Id;
            }
            else
            {
                var currentDateTime = DateTime.UtcNow;
                orderId = await AddAsync(storeId, userId, new Order()
                {
                    CreatedAt = currentDateTime,
                    CreatedBy = userId,
                    ModifiedAt = currentDateTime,
                    ModifiedBy = userId,
                    StoreId = storeId,
                    UserId = userId,
                    OrderStatus = OrderStatus.Open,
                    IsDeleted = false,
                    IsEnabled = true
                }).ConfigureAwait(false);
            }

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                var orderItemId = await conn.InsertAsync(new OrderItem { OrderId = orderId, ProductId = item.ProductId, ProductOptionId = item.ProductOptionId, Quantity = item.Quantity }).ConfigureAwait(false);

                return orderItemId;
            }
        }

        public Task<bool> DeleteAsync(long storeId, long userId, long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteOrderItemAsync(long storeId, long userId, long orderItemId)
        {
            string sql = @"UPDATE ""OrderItems""
                SET ""IsDeleted"" = false
                FROM ""OrderItems"" oi
                INNER JOIN ""Orders"" o on o.""Id"" = oi.""OrderId""
                WHERE o.""StoreId"" = @storeId
                    AND o.""UserId"" = @userId
                    AND o.""OrderStatus"" = @orderStatus
                    AND o.""IsDeleted"" = false
                    AND oi.""Id"" = @orderItemId;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var result = await conn.ExecuteAsync(sql, new { storeId, userId, orderItemId, orderStatus = OrderStatus.Open }).ConfigureAwait(false);

                return true;
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync(long storeId, long userId)
        {
            string sql = "SELECT * FROM \"Orders\" o WHERE o.\"StoreId\"=@storeId AND o.\"UserId\"=@userId AND o.\"OrderStatus\"<>@orderStatus AND o.\"IsDeleted\"=false;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var orders = await conn.QueryAsync<Order>(sql, new { storeId, userId, orderStatus = OrderStatus.Open }).ConfigureAwait(false);

                return orders.ToList();
            }
        }

        public async Task<Order> GetOrderByStatusAsync(long storeId, long userId, OrderStatus orderStatus)
        {
            string sql = "SELECT * FROM \"Orders\" o WHERE o.\"StoreId\"=@storeId AND o.\"UserId\"=@userId AND o.\"OrderStatus\"=@orderStatus AND o.\"IsDeleted\"=false;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var order = await conn.QueryAsync<Order>(sql, new { storeId, userId, orderStatus }).ConfigureAwait(false);

                return order.FirstOrDefault();
            }
        }

        public async Task<Order> GetSingleAsync(long storeId, long userId, long id)
        {
            string sql = "SELECT * FROM \"Orders\" o WHERE o.\"StoreId\"=@storeId AND o.\"UserId\"=@userId AND o.\"Id\"=@id AND o.\"IsDeleted\"=false;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var order = await conn.QueryAsync<Order>(sql, new { storeId, userId, id }).ConfigureAwait(false);

                return order.FirstOrDefault();
            }
        }

        public Task<bool> UpdateAsync(long storeId, long userId, Order record)
        {
            throw new NotImplementedException();
        }
    }
}
