using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(25, ErrorMessage = "max la 25 ki tu")]
        public string Username { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string Token { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}
