using E_Commerce.Application.Repositories;
using E_Commerce.Domain.Entities.Common;
using E_Commerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ECommerceAPIDbContext _context;

        // access ioc
        public ReadRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        //Set method: generic type entity
        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll()
        {
            return Table;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            return Table.Where(method);
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return await Table.SingleOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
    }
}
