using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task GetCreateAsync(T entity);
        Task GetUpdateAsync(T entity);
        Task GetDeleteAsync(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T,bool>> predicate);
    }
}
