using Supermarket.Core.Utilities;
using SupermarketAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Supermarket.Core.ViewModels
{
    public class PurchaseBillViewModel : BaseViewModel
    {
        public PurchaseBillViewModel() { }

        public PurchaseBillViewModel(PurchaseBill purchaseBill) 
        {
            this.PurchaseBillId = purchaseBill.PurchaseBillId;
            this.SupplierId = purchaseBill.SupplierId;
            this.Account = purchaseBill.Account;
            this.VAT = purchaseBill.VAT;
            this.Discount = purchaseBill.Discount;
            this.Note = purchaseBill.Note;
            //this.TotalMoney = purchaseBill.TotalMoney;
            this.CreatedDate = purchaseBill.CreatedDate;
            this.StaffId = purchaseBill.StaffId;
            if (purchaseBill.PurchaseBillDetails != null)
            {
                foreach (var item in purchaseBill.PurchaseBillDetails)
                {
                    var purchaseBillVM = new PurchaseBillDetailViewModel(item);
                    this.PurchaseBillDetailViewModels.Add(purchaseBillVM);
                }
            }
        }

        public string PurchaseBillId { get; set; }
        public int SupplierId { get; set; }

        private byte _discount;
        [Range(0, 100)]
        public byte Discount
        {
            get { return _discount; }
            set
            {
                OnPropertyChanged(ref _discount, value);
            }
        }

        private byte _VAT;
        [Range(0, 100)]
        public byte VAT
        {
            get { return _VAT; }
            set
            {
                OnPropertyChanged(ref _VAT, value);
            }
        }

        private long _totalMoney;
        public long TotalMoney
        {
            get
            {
                if (PurchaseBillDetailViewModels == null || PurchaseBillDetailViewModels.Count == 0)
                {
                    return 0;
                }
                long sum = 0;
                foreach (var item in PurchaseBillDetailViewModels)
                {
                    sum += (long)item.TotalMoney;
                }
                var vatMoney = sum * VAT / 100;
                var discountMoney = sum * Discount / 100;
                var total = sum - discountMoney + vatMoney;
                return total;
            }
            set
            {
                OnPropertyChanged(ref _totalMoney, value);
            }
        }

        private string _note;
        [MaxLength(255)]
        public string Note
        {
            get { return _note; }
            set
            {
                OnPropertyChanged(ref _note, value);
            }
        }

        private List<PurchaseBillDetailViewModel> _purchaseBillDetailViewModels = new List<PurchaseBillDetailViewModel>();
        public virtual List<PurchaseBillDetailViewModel> PurchaseBillDetailViewModels
        {
            get { return _purchaseBillDetailViewModels; }
            set
            {
                OnPropertyChanged(ref _purchaseBillDetailViewModels, value);
            }
        }

        public string TotalMoneyString
        {
            get
            {

                return string.Format("{0:n0}", TotalMoney);
            }
        }

        public string Account { get; set; }
        public int StaffId { get; set; }
        public DateTime CreatedDate { get; set; }

        public PurchaseBill MapToPuchaseBill()
        {
            PurchaseBill purchaseBill = new PurchaseBill()
            {
                PurchaseBillId = this.PurchaseBillId,
                SupplierId = this.SupplierId,
                Discount = this.Discount,
                Note = this.Note,
                VAT = this.VAT,
                TotalMoney = this.TotalMoney,
                CreatedDate = this.CreatedDate,
                StaffId = this.StaffId
            };

            return purchaseBill;
        }


    }
}
