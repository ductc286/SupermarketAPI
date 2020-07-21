namespace Supermarket.Core.ViewModels
{
    public class CurrentStaffViewModel
    {
        public int StaffId { get; set; }
        public string Account { get; set; }
        public int StaffRole { get; set; }

        public string RoleString { get; set; }
        public string Token { get; set; }
    }
}
