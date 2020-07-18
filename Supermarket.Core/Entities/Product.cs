using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Core.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [MaxLength(255)]
        public string Serial { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }

        public int SupplierId { get; set; }

        public int CategoryId { get; set; }

        public int Price { get; set; }

        public int Sold { get; set; } = 0;

        public int Inventory { get; set; } = 0;

        [Required]
        [MaxLength(255)]
        public string Unit { get; set; }

        public bool IsActive { get; set; } = true;

        [MaxLength(255)]
        public string Note { get; set; }

        public virtual ICollection<SaleBillDetail> SaleBillDetails { get; set; }
        public virtual ICollection<PurchaseBillDetail> PurchaseBillDetails { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
    }
}
