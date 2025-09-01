using System;
using System.Linq.Expressions;

namespace AuthServer.Core.Repositories;

public class IGenericRepository
{
    public class IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> GetAllAsync();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
