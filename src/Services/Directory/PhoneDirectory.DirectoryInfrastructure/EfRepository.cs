using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Shared.Interfaces;
using PhoneDirectory.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryInfrastructure
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class,IEntity, IAggregateRoot
    {
        protected readonly DirectoryDbContext _dbContext;

        public EfRepository(DirectoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }


        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(filter);
        }
        public async Task<T> Get(Expression<Func<T, bool>> filter,string include)
        {
            return await _dbContext.Set<T>().Include(include).SingleOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

      
    }
}
