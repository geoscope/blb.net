﻿using System;
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

        public Task<long> AddAsync(long storeId, Category record)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long storeId, Category record)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync(long storeId)
        {
            string sql = "SELECT * FROM \"Categories\" c WHERE c.\"StoreId\"=@storeId AND c.\"IsDeleted\"=false ORDER BY c.\"ParentCategoryId\" NULLS FIRST;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var categories = await conn.QueryAsync<Category>(sql, new { storeId }).ConfigureAwait(false);

                return categories;
            }
        }

        public async Task<Category> GetSingleAsync(long storeId, long id)
        {
            string sql = "SELECT * FROM \"Categories\" c WHERE c.\"Id\"=@id AND c.\"StoreId\"=@storeId AND c.\"IsDeleted\"=false;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var category = await conn.QueryAsync<Category>(sql, new { id, storeId }).ConfigureAwait(false);

                return category.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Category>> GetSingleWithChildrenAsync(long storeId, long categoryId)
        {
            string sql = @"WITH RECURSIVE category_tree AS (
                SELECT c.""Id"", c.""Name"", c.""ParentCategoryId"" 
                    FROM ""Categories"" c WHERE c.""Id"" = @catgoryId and c.""StoreId"" = @storeId
                UNION
                SELECT c.""Id"", c.""Name"", c.""ParentCategoryId""
                    FROM ""Categories"" c
                    JOIN category_tree ON (c.""ParentCategoryId"" = category_tree.""Id"") AND c.""StoreId"" = @storeId
            )
            SELECT * FROM category_tree;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var categories = await conn.QueryAsync<Category>(sql, new { storeId, categoryId }).ConfigureAwait(false);

                return categories;
            }
        }

        public Task<bool> UpdateAsync(long storeId, Category record)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetSingleWithParentsAsync(long storeId, long categoryId)
        {
            string sql = @"WITH RECURSIVE category_tree AS (
                SELECT c.""Id"", c.""Name"" , c.""ParentCategoryId"" FROM ""Categories"" c WHERE c.""Id""=@categoryId AND c.""StoreId""=@storeId 
                    UNION
                SELECT c.""Id"", c.""Name"", c.""ParentCategoryId""
                    FROM ""Categories"" c
                    JOIN category_tree ON (c.""Id"" = category_tree.""ParentCategoryId"") AND c.""StoreId""=@storeId
                )
                SELECT * FROM category_tree;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var categories = await conn.QueryAsync<Category>(sql, new { storeId, categoryId }).ConfigureAwait(false);

                return categories;
            }
        }
    }
}
