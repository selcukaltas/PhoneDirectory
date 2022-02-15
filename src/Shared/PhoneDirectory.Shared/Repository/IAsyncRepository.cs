using PhoneDirectory.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Shared.Repository
{
    public interface IAsyncRepository<T> where T : IAggregateRoot,IEntity
    {
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    }
}
