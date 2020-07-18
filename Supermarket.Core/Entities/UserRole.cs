namespace Supermarket.Core.Entities
{
    public class UserRole
    {
        //[Key]
        public int RoleId { get; set; }
        //[Key]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public  Role Role { get; set; }
    }
}
