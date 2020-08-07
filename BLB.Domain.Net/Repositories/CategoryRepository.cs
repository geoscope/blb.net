using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLB.Domain.Net.Interfaces;
using BLB.Domain.Net.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BLB.Domain.Net.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string connectionString = null;

        public CategoryRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BLBConnectionString");
        }

        public long Add(long storeId, Category record)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddAsync(long storeId, Category record)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long storeId, Category record)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long storeId, Category record)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync(long storeId)
        {
            string sql = "SELECT * FROM \"Categories\" c WHERE c.\"StoreId\"=@storeId AND c.\"IsDeleteted\"=false ORDER BY c.\"ParentCategoryId\" NULLS FIRST;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var categories = await conn.QueryAsync<Category>(sql, new { storeId }).ConfigureAwait(false);

                return categories;
            }
        }

        public IEnumerable<Category> GetAll(long storeId)
        {
            string sql = "SELECT * FROM \"Categories\" c WHERE c.\"StoreId\"=@storeId AND c.\"IsDeleteted\"=false ORDER BY c.\"ParentCategoryId\" NULLS FIRST;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var categories = conn.Query<Category>(sql, new { storeId });

                return categories;
            }
        }

        public Category GetSingle(long storeId, long id)
        {
            string sql = "SELECT * FROM \"Categories\" c WHERE c.\"Id\"=@id AND c.\"StoreId\"=@storeId AND c.\"IsDeleteted\"=false;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var category = conn.Query<Category>(sql, new { id, storeId });

                return category.FirstOrDefault();
            }
        }

        public async Task<Category> GetSingleAsync(long storeId, long id)
        {
            string sql = "SELECT * FROM \"Categories\" c WHERE c.\"Id\"=@id AND c.\"StoreId\"=@storeId AND c.\"IsDeleteted\"=false;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var category = await conn.QueryAsync<Category>(sql, new { id, storeId }).ConfigureAwait(false);

                return category.FirstOrDefault();
            }
        }

        public IEnumerable<Category> GetSingleWithChildren(long storeId, long parentCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetSingleWithChildrenAsync(long storeId, long parentCategoryId)
        {
            throw new NotImplementedException();
        }

        public bool Update(long storeId, Category record)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long storeId, Category record)
        {
            throw new NotImplementedException();
        }
    }
}
