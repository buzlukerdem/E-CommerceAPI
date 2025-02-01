using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Contexts
{
    public class ECommerceAPIDbContext : DbContext
    {
        // IOC Container access
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        // Database Tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        // Interceptor  add default value on table
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // tracked objects in datas
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                    data.Entity.CreatedTime = DateTime.UtcNow;
                else if (data.State == EntityState.Modified)
                    data.Entity.UpdatedTime = DateTime.UtcNow;
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        #region seed data
        // guid is problem for seed data...
        // Seed Data
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Product>()
        //        .HasData(
        //            new Product() { Id = Guid.NewGuid(), Name = "A Product", Price = 100, Stock = 10, CreatedTime = DateTime.UtcNow },
        //            new Product() { Id = Guid.NewGuid(), Name = "B Product", Price = 200, Stock = 20, CreatedTime = DateTime.UtcNow },
        //            new Product() { Id = Guid.NewGuid(), Name = "C Product", Price = 300, Stock = 30, CreatedTime = DateTime.UtcNow },
        //            new Product() { Id = Guid.NewGuid(), Name = "D Product", Price = 400, Stock = 40, CreatedTime = DateTime.UtcNow },
        //            new Product() { Id = Guid.NewGuid(), Name = "E Product", Price = 500, Stock = 50, CreatedTime = DateTime.UtcNow }
        //        );
        //    modelBuilder.Entity<Customer>()
        //      .HasData(
        //          new Customer() { Id = Guid.NewGuid(), Name = "Erdem Buzluk", CreatedTime = DateTime.UtcNow },
        //          new Customer() { Id = Guid.NewGuid(), Name = "Nesrin Alya", CreatedTime = DateTime.UtcNow },
        //          new Customer() { Id = Guid.NewGuid(), Name = "Kadir Demir", CreatedTime = DateTime.UtcNow },
        //          new Customer() { Id = Guid.NewGuid(), Name = "Berkay Oral", CreatedTime = DateTime.UtcNow },
        //          new Customer() { Id = Guid.NewGuid(), Name = "Deniz Çoban", CreatedTime = DateTime.UtcNow }
        //      );

        //}
        #endregion

    }
}
