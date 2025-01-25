using E_Commerce.Application.Abstractions;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new(){Id =  Guid.NewGuid(),ProductName="A Product",ProductPrice=100, ProductStok=250},
                 new(){Id =  Guid.NewGuid(),ProductName="C Product",ProductPrice=1200, ProductStok=50},
                  new(){Id =  Guid.NewGuid(),ProductName="B Product",ProductPrice=1500, ProductStok=25},
            };
        }
    }
}
