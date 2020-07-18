using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using System.Collections.Generic;

namespace Supperket.BLL.IBusiness
{

    public interface IEndOfShiftBusiness
    {
        List<EndOfShift> GetAll();
        bool Delete(EndOfShift entity);
        bool Add(EndOfShiftViewModel entity);

        void Approve(EndOfShift entity);
        bool Update(EndOfShiftViewModel entity);
    }
}
