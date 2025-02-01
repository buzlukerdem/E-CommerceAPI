using Microsoft.EntityFrameworkCore;
using E_Commerce.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using E_Commerce.Application.Repositories.ICustomer;
using E_Commerce.Persistence.Repositories;
using E_Commerce.Application.Repositories.IOrder;
using E_Commerce.Application.Repositories.IProduct;

namespace E_Commerce.Persistence
{
    // Extension Method
    public static class ServiceRegistration
    {
        public static void AddPermistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
