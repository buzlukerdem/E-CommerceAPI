using E_Commerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //findasync method - efcore orm
        Task<T> GetByIdAsync(string id);
        // firstordefaultasync method
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        IQueryable<T> GetAll();
        // Return value bool, T parameter
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);


    }
}
