using E_Commerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        // ADD-DELETE-UPDATE OPERATIONS
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> models);
        bool Remove(T model);
        Task<bool> Remove(string id);
        bool RemoveRange(List<T> models);
        bool UpdateAsync(T model);
        bool UpdateRange(List<T> models);

        //SaveChanges method
        Task<int> SaveChanges();
    }
}
