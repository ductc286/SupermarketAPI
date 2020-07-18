using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using System.Collections.Generic;

namespace Supperket.BLL.IBusiness
{

    public interface ICategoryBusiness
    {
        Category GetById(object id);
        List<Category> GetAll();
        bool Delete(object id);
        bool Add(CategoryViewModel entity);
        bool Update(CategoryViewModel entity);
    }
}
