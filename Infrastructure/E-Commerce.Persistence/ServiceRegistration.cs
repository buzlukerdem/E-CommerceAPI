﻿using Microsoft.EntityFrameworkCore;
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
using E_Commerce.Application.Repositories.IFile;
using E_Commerce.Application.Repositories.IProductImageFile;
using E_Commerce.Application.Repositories.IInvoiceFile;

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
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
        }
    }
}
