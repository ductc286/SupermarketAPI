using System.Collections.Generic;

namespace Supperket.BLL.BaseBusiness
{
    public interface IBaseActionOfObject<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        List<TEntity> GetAll();
        bool Delete(object id);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
    }
}
