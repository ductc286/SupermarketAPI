using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using System.Collections.Generic;

namespace Supperket.BLL.IBusiness
{
    public interface ISupplierBusiness
    {
        Supplier GetById(object id);
        List<Supplier> GetAll();
        bool Delete(object id);
        bool Add(SupplierViewModel entity);
        bool Update(SupplierViewModel entity);
    }
}
