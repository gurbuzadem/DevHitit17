using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevHitit17Database.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // Get Operations
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        // Find Operations
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindOne(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate);

        // Add Operations
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // Remove Operations
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
