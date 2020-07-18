using Microsoft.EntityFrameworkCore;
using SupermarketAPI.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace SupermarketAPI.DAL.GenericRepository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Fields
        protected readonly MyDBContext MyContext;
        protected readonly DbSet<TEntity> MyDbSet;
        #endregion


        #region Constructor
        public GenericRepository()
        {

        }
        public GenericRepository(MyDBContext db)
        {
            MyContext = db;
            MyDbSet = MyContext.Set<TEntity>();
        }
        #endregion

        #region Implements

        public virtual TEntity GetById(object id)
        {
            return MyDbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await MyDbSet.FindAsync(id);
        }

        public virtual bool Add(TEntity entity)
        {
            MyDbSet.Add(entity);
            var changeCount = MyContext.SaveChanges();
            return changeCount > 0;
        }
        public virtual bool AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return false;
            }
            MyDbSet.AddRange(entities);
            var changeCount = MyContext.SaveChanges();
            return changeCount == entities.Count();
        }
        public virtual int Count()
        {
            return MyDbSet.Count();
        }

        public virtual Task<int> CountAsync()
        {
            return MyDbSet.CountAsync();
        }

        public virtual bool Update(TEntity entity)
        {
            MyDbSet.Update(entity);
            var changeCount = MyContext.SaveChanges();
            return changeCount > 0;
        }

        public virtual bool UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return false;
            }
            MyDbSet.UpdateRange(entities.ToArray());
            var changeCount = MyContext.SaveChanges();
            return changeCount == entities.Count();
        }

        public virtual bool Delete(TEntity entity)
        {
            MyDbSet.Remove(entity);
            var changeCount = MyContext.SaveChanges();
            return changeCount > 0;
        }
        public virtual bool DeleteRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return false;
            }
            MyDbSet.RemoveRange(entities);
            var changeCount = MyContext.SaveChanges();
            return changeCount == entities.Count();
        }
        public virtual IEnumerable<TEntity> DeleteBy(Expression<Func<TEntity, bool>> filter)
        {
            IEnumerable<TEntity> entities = MyDbSet.Where(filter).AsEnumerable();
            MyDbSet.RemoveRange(entities);
            MyContext.SaveChanges();
            return new List<TEntity>();
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            return MyDbSet.Where(filter).FirstOrDefault();
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await MyDbSet.Where(filter).FirstOrDefaultAsync();
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return MyDbSet.Where(filter).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await MyDbSet.Where(filter).ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return MyDbSet.Where(filter);
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = MyDbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return orderBy != null ? orderBy(query) : query;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return MyDbSet;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await MyDbSet.ToListAsync();
        }

        public virtual void Dispose()
        {
            MyContext.Dispose();
        }


        #endregion
    }
}