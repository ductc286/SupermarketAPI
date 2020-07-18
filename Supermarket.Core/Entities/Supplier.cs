using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Core.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(255)]
        public string SupplierName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
