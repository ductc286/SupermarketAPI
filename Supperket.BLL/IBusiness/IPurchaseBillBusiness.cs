using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using System.Collections.Generic;

namespace Supperket.BLL.IBusiness
{
    public interface IPurchaseBillBusiness
    {
        PurchaseBill GetById(object id);
        List<PurchaseBill> GetAll();
        bool Delete(object id);
        bool Add(PurchaseBillViewModel entity);
        bool Update(PurchaseBillViewModel entity);
    }
}
