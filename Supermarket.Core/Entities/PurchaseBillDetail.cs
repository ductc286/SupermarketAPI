using System;
using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Core.Entities
{
    public class PurchaseBillDetail
    {
        [Key]
        [MaxLength(255)]
        public string Id { get; set; }

        [MaxLength(30)]
        public string PurchaseBillId { get; set; }

        public int ProductId { get; set; }

        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }

        public int Price { get; set; }

        public long TotalMoney { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        public virtual PurchaseBill PurchaseBill { get; set; }
        public virtual Product Product { get; set; }
    }
}
