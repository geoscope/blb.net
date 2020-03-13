using BLB.Domain.Net.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BLB.Domain.Net
{
    internal class BLBDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<UserInUserRole> UserInUserRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var created = ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in created)
            {
                if (entity is BaseEntity)
                {
                    var track = entity as BaseEntity;
                    track.CreatedAt = DateTime.Now;
                    track.ModifiedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            ChangeTracker.DetectChanges();
            var created = ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in created)
            {
                if (entity is BaseEntity)
                {
                    var track = entity as BaseEntity;
                    track.CreatedAt = DateTime.Now;
                    track.ModifiedAt = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("BLBConnectionString");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Missing BLBConnectionString environment variable");

            options.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "Default Values"

            modelBuilder.Entity<ProductImage>()
                .Property(p => p.SortOrder)
                .HasDefaultValue(0);

            modelBuilder.Entity<ProductOption>()
                .Property(p => p.SortOrder)
                .HasDefaultValue(0);

            #endregion "Default Values"

            #region "Indexes"

            modelBuilder.Entity<ProductAttribute>()
                .HasIndex(p => p.ProductId);

            #endregion "Indexes"
        }
    }
}