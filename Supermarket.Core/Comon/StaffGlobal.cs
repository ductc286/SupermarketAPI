using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using System;

namespace Supermarket.Core.Comon
{
    public static class StaffGlobal
    {
        public static CurrentStaffViewModel CurrentStaff { get; set; } = new CurrentStaffViewModel() { Account = "Admin", StaffId = 1, StaffRole = 1 };

        public static string Test = "test";
        public static string Account
        {
            get
            {
                var result = (CurrentStaff != null) ? CurrentStaff.Account : "";
                return result;
            }
        }
        public static int StaffId
        {
            get
            {
                var result = (CurrentStaff != null) ? CurrentStaff.StaffId : 0;
                return result;
            }
        }
        public static string StaffRole
        {
            get
            {
                if (CurrentStaff == null)
                {
                    return "";
                }
                string result = Enum.GetName(typeof(EStaffRole), CurrentStaff.StaffRole);
                return result;
            }
        }



    }
}
