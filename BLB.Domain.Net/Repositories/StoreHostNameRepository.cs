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
    public class StoreHostNameRepository : IStoreHostNameRepository
    {
        private readonly string connectionString;

        public StoreHostNameRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BLBConnectionString");
        }

        public long Add(StoreHostName record)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> AddAsync(StoreHostName record)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(StoreHostName record)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(StoreHostName record)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<StoreHostName> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<StoreHostName>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public StoreHostName GetSingle(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<StoreHostName> GetSingleAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public StoreHostName GetByHostName(string hostName)
        {
            string sql = "SELECT * FROM \"StoreHostNames\" s WHERE s.\"HostName\" ILIKE @hostName AND s.\"IsEnabled\"=true AND s.\"IsDeleted\"=false;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var storeHostName = conn.Query<StoreHostName>(sql, new { hostName });

                return storeHostName.FirstOrDefault();
            }
        }

        public async Task<StoreHostName> GetByHostNameAsync(string hostName)
        {
            string sql = "SELECT * FROM \"StoreHostNames\" s WHERE s.\"HostName\" ILIKE @hostName AND s.\"IsEnabled\"=true AND s.\"IsDeleted\"=false;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var storeHostName = await conn.QueryAsync<StoreHostName>(sql, new { hostName }).ConfigureAwait(false);

                return storeHostName.FirstOrDefault();
            }
        }

        public bool Update(StoreHostName record)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(StoreHostName record)
        {
            throw new System.NotImplementedException();
        }
    }
}