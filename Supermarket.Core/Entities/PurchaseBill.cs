using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Core.Entities
{
    public class PurchaseBill
    {
        [Key]
        [MaxLength(30)]
        public string PurchaseBillId { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName
        {
            get
            {
                return Supplier.SupplierName;
            }
        }

        [Range(0, 100)]
        public byte Discount { get; set; }

        [Range(0, 100)]
        public byte VAT { get; set; }

        public long TotalMoney { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StaffId { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        public virtual ICollection<PurchaseBillDetail> PurchaseBillDetails { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Supplier Supplier { get; set; }

        #region For Only Getdata
        public string Account
        {
            get
            {
                return Staff.Account;
            }
        }

        public int NumberTypeProduct
        {
            get
            {
                if (PurchaseBillDetails == null)
                {
                    return 0;
                }
                return PurchaseBillDetails.Count;
            }
        }
        #endregion
    }
}
