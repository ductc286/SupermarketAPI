using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using System.Collections.Generic;

namespace Supperket.BLL.IBusiness
{
    public interface IStaffBusiness
    {
        CurrentStaffViewModel GetStaffViewModel(LoginStaffViewModel loginStaffViewModel);

        bool Add(StaffViewModel entity);
        bool Update(StaffViewModel entity);
        List<Staff> GetAll();
        bool ChangePassword(ChangePasswordViewModel changePasswordViewModel);
    }
}
