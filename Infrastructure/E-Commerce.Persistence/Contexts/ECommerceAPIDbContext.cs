using E_Commerce.Domain.Entities;
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
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
