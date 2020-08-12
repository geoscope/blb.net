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
    public class ProductRepository : IProductRepository
    {
        private readonly string connectionString = null;

        public ProductRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BLBConnectionString");
        }

        public long Add(long storeId, Product record)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> AddAsync(long storeId, Product record)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(long storeId, Product record)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(long storeId, Product record)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll(long storeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync(long storeId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategory(long storeId, long categoryId, int page, int pageSize)
        {
            string sql = $@"SELECT * FROM ""Products"" p
                INNER JOIN ""ProductInCategories"" pc ON pc.""ProductId"" = p.""Id""
                LEFT JOIN ""ProductAttributes"" pa ON pa.""ProductId"" = p.""Id"" 
                LEFT JOIN ""ProductImages"" pim ON pim.""ProductId"" = p.""Id""
                LEFT JOIN ""ProductOptions"" po ON po.""ProductId"" = p.""Id"" 
                WHERE p.""StoreId"" = @storeId AND pc.""CategoryId"" = @categoryId
                    AND p.""IsDeleted"" = false AND p.""IsEnabled"" = true 
                    AND coalesce(pa.""IsDeleted"", false) = false AND coalesce(pa.""IsEnabled"", true) = true 
                    AND coalesce(pim.""IsDeleted"", false) = false AND coalesce(pim.""IsEnabled"", true) = true
                    AND coalesce(po.""IsDeleted"", false) = false AND coalesce(po.""IsEnabled"", true) = true
                LIMIT {pageSize} OFFSET {pageSize * (page - 1)};";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var productDictionary = new Dictionary<long, Product>();

                var products = conn.Query<Product, ProductAttribute, Product>(sql, (product, productAttribute) =>
                {
                    Product productEntry;

                    if (!productDictionary.TryGetValue(product.Id, out productEntry))
                    {
                        productEntry = product;
                        productEntry.ProductAttributes = new List<ProductAttribute>();
                        productDictionary.Add(productEntry.Id, productEntry);
                    }

                    productEntry.ProductAttributes.Add(productAttribute);
                    return productEntry;
                },
                new { storeId, categoryId },
                splitOn: "ProductId");

                return products;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(long storeId, long categoryId, int page, int pageSize)
        {
            string sql = $@"SELECT * FROM ""Products"" p
                INNER JOIN ""ProductInCategories"" pc ON pc.""ProductId"" = p.""Id""
                LEFT JOIN ""ProductAttributes"" pa ON pa.""ProductId"" = p.""Id"" 
                LEFT JOIN ""ProductImages"" pim ON pim.""ProductId"" = p.""Id""
                LEFT JOIN ""ProductOptions"" po ON po.""ProductId"" = p.""Id"" 
                WHERE p.""StoreId"" = @storeId AND pc.""CategoryId"" = @categoryId
                    AND p.""IsDeleted"" = false AND p.""IsEnabled"" = true 
                    AND coalesce(pa.""IsDeleted"", false) = false AND coalesce(pa.""IsEnabled"", true) = true 
                    AND coalesce(pim.""IsDeleted"", false) = false AND coalesce(pim.""IsEnabled"", true) = true
                    AND coalesce(po.""IsDeleted"", false) = false AND coalesce(po.""IsEnabled"", true) = true
                LIMIT {pageSize} OFFSET {pageSize * (page - 1)};";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var productDictionary = new Dictionary<long, Product>();

                var products = await conn.QueryAsync<Product, ProductAttribute, Product>(sql, (product, productAttribute) =>
                {
                    Product productEntry;

                    if (!productDictionary.TryGetValue(product.Id, out productEntry))
                    {
                        productEntry = product;
                        productEntry.ProductAttributes = new List<ProductAttribute>();
                        productDictionary.Add(productEntry.Id, productEntry);
                    }

                    productEntry.ProductAttributes.Add(productAttribute);
                    return productEntry;
                },
                new { storeId, categoryId },
                splitOn: "ProductId");

                return products;
            }
        }

        public Product GetSingle(long storeId, long id)
        {
            string sql = $@"SELECT * FROM ""Products"" p
                INNER JOIN ""ProductInCategories"" pc ON pc.""ProductId"" = p.""Id""
                LEFT JOIN ""ProductAttributes"" pa ON pa.""ProductId"" = p.""Id"" 
                LEFT JOIN ""ProductImages"" pim ON pim.""ProductId"" = p.""Id""
                LEFT JOIN ""ProductOptions"" po ON po.""ProductId"" = p.""Id"" 
                WHERE p.""StoreId"" = @storeId AND p.""Id"" = @id
                    AND p.""IsDeleted"" = false AND p.""IsEnabled"" = true 
                    AND coalesce(pa.""IsDeleted"", false) = false AND coalesce(pa.""IsEnabled"", true) = true 
                    AND coalesce(pim.""IsDeleted"", false) = false AND coalesce(pim.""IsEnabled"", true) = true
                    AND coalesce(po.""IsDeleted"", false) = false AND coalesce(po.""IsEnabled"", true) = true;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var productDictionary = new Dictionary<long, Product>();

                var product = conn.Query<Product, ProductAttribute, Product>(sql, (product, productAttribute) =>
                {
                    Product productEntry;

                    if (!productDictionary.TryGetValue(product.Id, out productEntry))
                    {
                        productEntry = product;
                        productEntry.ProductAttributes = new List<ProductAttribute>();
                        productDictionary.Add(productEntry.Id, productEntry);
                    }

                    productEntry.ProductAttributes.Add(productAttribute);
                    return productEntry;
                },
                new { storeId, id },
                splitOn: "ProductId");

                return product.FirstOrDefault();
            }
        }

        public async Task<Product> GetSingleAsync(long storeId, long id)
        {
            string sql = $@"SELECT * FROM ""Products"" p
                INNER JOIN ""ProductInCategories"" pc ON pc.""ProductId"" = p.""Id""
                LEFT JOIN ""ProductAttributes"" pa ON pa.""ProductId"" = p.""Id"" 
                LEFT JOIN ""ProductImages"" pim ON pim.""ProductId"" = p.""Id""
                LEFT JOIN ""ProductOptions"" po ON po.""ProductId"" = p.""Id"" 
                WHERE p.""StoreId"" = @storeId AND p.""Id"" = @id
                    AND p.""IsDeleted"" = false AND p.""IsEnabled"" = true 
                    AND coalesce(pa.""IsDeleted"", false) = false AND coalesce(pa.""IsEnabled"", true) = true 
                    AND coalesce(pim.""IsDeleted"", false) = false AND coalesce(pim.""IsEnabled"", true) = true
                    AND coalesce(po.""IsDeleted"", false) = false AND coalesce(po.""IsEnabled"", true) = true;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var productDictionary = new Dictionary<long, Product>();

                var product = await conn.QueryAsync<Product, ProductAttribute, Product>(sql, (product, productAttribute) =>
                {
                    Product productEntry;

                    if (!productDictionary.TryGetValue(product.Id, out productEntry))
                    {
                        productEntry = product;
                        productEntry.ProductAttributes = new List<ProductAttribute>();
                        productDictionary.Add(productEntry.Id, productEntry);
                    }

                    productEntry.ProductAttributes.Add(productAttribute);
                    return productEntry;
                },
                new { storeId, id },
                splitOn: "ProductId");

                return product.FirstOrDefault();
            }
        }

        public bool Update(long storeId, Product record)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(long storeId, Product record)
        {
            throw new System.NotImplementedException();
        }
    }
}