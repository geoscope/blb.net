using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLB.Domain.Net.Interfaces;
using BLB.Domain.Net.Models;
using BLB.Shared.Net.Interfaces;
using BLB.Shared.Net.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;

namespace BLB.Domain.Net.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;
        private readonly AppSettings appSettings;
        private readonly ISecurityHelper securityHelper;

        public UserRepository(IConfiguration configuration, IOptions<AppSettings> appSettings, ISecurityHelper securityHelper)
        {
            if (appSettings == null)
                throw new ArgumentNullException(nameof(appSettings));

            connectionString = configuration.GetConnectionString("BLBConnectionString");
            this.appSettings = appSettings.Value;
            this.securityHelper = securityHelper;
        }

        public long Add(User record)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddAsync(User record)
        {
            throw new NotImplementedException();
        }

        public User AuthenticateUser(string username, string password)
        {
            // Get the user record - for the salt
            var user = GetByUserName(username);

            if (user != null)
            {
                var hashedPassword = securityHelper.HashPassword(password, appSettings.SystemSalt, user.UserSalt);

                var sql = "SELECT * FROM \"Users\" u WHERE u.\"UserName\"=@username AND u.\"Password\"=@hashedPassword AND u.\"IsDeleteted\"=false AND u.\"IsEnabled\"=true;";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    var authenticatedUser = conn.Query<User>(sql, new { username, hashedPassword });

                    return authenticatedUser.FirstOrDefault();
                }
            }

            return null;
        }

        public Task<User> AuthenticateUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User record)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(User record)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public User GetByUserName(string username)
        {
            var sql = "SELECT * FROM \"Users\" u WHERE u.\"UserName\"=@username AND u.\"IsDeleteted\"=false AND u.\"IsEnabled\"=true;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var user = conn.Query<User>(sql, new { username });

                return user.First();
            }
        }

        public async Task<User> GetByUserNameAsync(string username)
        {
            var sql = "SELECT * FROM \"Users\" u WHERE u.\"UserName\"=@username AND u.\"IsDeleteted\"=false AND u.\"IsEnabled\"=true;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var user = await conn.QueryAsync<User>(sql, new { username });

                return user.First();
            }
        }

        public User GetSingle(long id)
        {
            var sql = "SELECT * FROM \"Users\" u WHERE u.\"Id\"=@id AND u.\"IsDeleteted\"=false AND u.\"IsEnabled\"=true;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var user = conn.Query<User>(sql, new { id });

                return user.First();
            }
        }

        public async Task<User> GetSingleAsync(long id)
        {
            var sql = "SELECT * FROM \"Users\" u WHERE u.\"Id\"=@id AND u.\"IsDeleteted\"=false AND u.\"IsEnabled\"=true;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var user = await conn.QueryAsync<User>(sql, new { id });

                return user.First();
            }
        }

        public bool Update(User record)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(User record)
        {
            throw new NotImplementedException();
        }
    }
}
