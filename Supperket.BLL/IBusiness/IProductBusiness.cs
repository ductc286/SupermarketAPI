using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using System.Collections.Generic;

namespace Supperket.BLL.IBusiness
{
    public interface IProductBusiness
    {
        Product GetById(object id);
        List<Product> GetAll();
        bool Delete(object id);
        bool Add(ProductViewModel entity);
        bool Update(ProductViewModel entity);
    }
}
