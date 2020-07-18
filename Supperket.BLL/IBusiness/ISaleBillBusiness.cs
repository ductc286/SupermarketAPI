using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using System.Collections.Generic;

namespace Supperket.BLL.IBusiness
{
    public interface ISaleBillBusiness
    {
        SaleBill GetById(object id);
        List<SaleBill> GetAll();
        bool Delete(SaleBill saleBill);
        bool Add(SaleBillViewModel entity);
        bool Update(SaleBillViewModel entity);
    }
}
