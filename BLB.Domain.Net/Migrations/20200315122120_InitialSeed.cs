using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Linq;

namespace BLB.Domain.Net.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new Exception("migrationBuilder is null");

            migrationBuilder.Sql(@"DELETE FROM public.""Stores"" WHERE ""Code""='DEMO-STORE';");

            migrationBuilder.Sql(@"DELETE FROM public.""Users"" WHERE ""UserName""='demo@mydemostore.com';");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new Exception("migrationBuilder is null");

            migrationBuilder.Sql(@"INSERT INTO public.""Stores""
                (""CreatedAt"", ""CreatedBy"", ""IsDeleteted"", ""IsEnabled"", ""ModifiedAt"", ""ModifiedBy"", ""Code"", ""DefaultPercentageMargin"", ""DefaultProductImageUri"", ""Description"", ""Name"", ""Summary"")
                VALUES(CURRENT_TIMESTAMP, 1, false, true, CURRENT_TIMESTAMP, 1, 'DEMO-STORE', 20, null, null, 'Demo Store', 'The best demo store ever!');
            ");

            var userSalt = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 12).Select(s => s[new Random().Next(s.Length)]).ToArray());

            migrationBuilder.Sql(@$"INSERT INTO public.""Users""
                (""CreatedAt"", ""CreatedBy"", ""IsDeleteted"", ""IsEnabled"", ""ModifiedAt"", ""ModifiedBy"", ""EmailAddress"", ""ExternalUserId"", ""FirstName"", ""HashedVerificationCode"", ""IsUserLockedOut"", ""IsUserVerified"", ""LastName"", ""Password"", ""StoreId"", ""UserLockedEndDate"", ""UserName"", ""UserSalt"")
                VALUES(CURRENT_TIMESTAMP, 1, false, true, CURRENT_TIMESTAMP, 1, 'demo@mydemostore.com', null, 'Demo', '', false, true, 'User', '', (SELECT ""Id"" FROM public.""Stores"" WHERE ""Code""='DEMO-STORE' LIMIT 1), null, 'demo@mydemostore.com', '{userSalt}');
            ");
        }
    }
}