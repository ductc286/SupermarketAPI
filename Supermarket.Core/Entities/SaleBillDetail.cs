using System;
using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Core.Entities
{
    public class SaleBillDetail
    {
        [Key]
        [MaxLength(255)]
        public string Id { get; set; }

        public string SaleBillId { get; set; }

        public int ProductId { get; set; }

        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }

        public int Price { get; set; }

        public long TotalMoney { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        public virtual SaleBill SaleBill { get; set; }
        public virtual Product Product { get; set; }
    }
}
