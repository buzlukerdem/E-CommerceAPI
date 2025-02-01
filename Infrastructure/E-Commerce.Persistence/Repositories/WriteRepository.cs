using E_Commerce.Application.Repositories;
using E_Commerce.Domain.Entities.Common;
using E_Commerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ECommerceAPIDbContext _context;

        public WriteRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        //Set method: generic type entity
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entity = await Table.AddAsync(model);
            return entity.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entity = Table.Remove(model);
            return entity.State == EntityState.Deleted;
            //SAVECHANGES
        }
        public bool RemoveRange(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public async Task<bool> Remove(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(model);
        }

        public bool UpdateAsync(T model)
        {
            EntityEntry<T> entity = Table.Update(model);
            return entity.State == EntityState.Modified;
        }

        public bool UpdateRange(List<T> models)
        {
            Table.UpdateRange(models);
            return true;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();

        }

    }
}
