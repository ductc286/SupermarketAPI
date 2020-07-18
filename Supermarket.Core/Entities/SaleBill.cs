using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Core.Entities
{
    public class SaleBill
    {
        [Key]
        [MaxLength(30)]
        public string SaleBillId { get; set; }

        [Range(0, 100)]
        public byte Discount { get; set; }

        public long TotalMoney { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StaffId { get; set; }

        public bool IsAprroved { get; set; } = false;

        [MaxLength(255)]
        public string Note { get; set; }

        public virtual ICollection<SaleBillDetail> SaleBillDetails { get; set; }
        public virtual Staff Staff { get; set; }

        #region For Only Getdata
        public int NumberTypeProduct
        {
            get
            {
                if (SaleBillDetails == null)
                {
                    return 0;
                }
                return SaleBillDetails.Count;
            }
        }
        #endregion
    }

    
}
