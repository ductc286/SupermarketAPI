using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupermarketAPI.DAL.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);
        bool UpdateRange(IEnumerable<TEntity> entities);
        bool Delete(TEntity entity);
        bool DeleteRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> DeleteBy(Expression<Func<TEntity, bool>> filter);

        int Count();
        Task<int> CountAsync();

        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);

        IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity Find(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);

        void Dispose();
    }
}
