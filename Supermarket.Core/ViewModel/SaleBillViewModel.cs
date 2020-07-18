using SupermarketAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Core.ViewModels
{
    public class SaleBillViewModel : BaseViewModel
    {
        public SaleBillViewModel() { }

        public SaleBillViewModel(SaleBill saleBill)
        {
            this.SaleBillId = saleBill.SaleBillId;
            this.Discount = saleBill.Discount;
            this.TotalMoney = saleBill.TotalMoney;
            this.CreatedDate = saleBill.CreatedDate;
            this.StaffId = saleBill.StaffId;
            this.Account = saleBill.Staff.Account;
            this.Note = saleBill.Note;
            this.IsAprroved = saleBill.IsAprroved;
            this.SaleBillDetailViewModels = new List<SaleBillDetailViewModel>();
            foreach (var item in saleBill.SaleBillDetails)
            {
                var saleBillDetailViewModel = new SaleBillDetailViewModel(item);
                this.SaleBillDetailViewModels.Add(saleBillDetailViewModel);
            }
        }

        [MaxLength(30, ErrorMessage = "Mã đơn bán hàng có độ dài tối đa là {1}")]

        public string SaleBillId { get; set; }

        private byte _discount;
        [Range(0, 100, ErrorMessage = "Chiết khẩu có giá trị trong khoảng {1} đến {2}")]
        public byte Discount
        {
            get { return _discount; }
            set
            {
                OnPropertyChanged(ref _discount, value);
            }
        }

        private long _totalMoney = 0;
        public long TotalMoney
        {
            get
            {
                if (SaleBillDetailViewModels == null || SaleBillDetailViewModels.Count == 0)
                {
                    return 0;
                }
                long sum = 0;
                foreach (var item in SaleBillDetailViewModels)
                {
                    sum += (long)item.TotalMoney;
                }
                var discountMoney = sum * Discount / 100;
                var total = sum - discountMoney;
                return total;
            }
            set
            {
                OnPropertyChanged(ref _totalMoney, TotalMoney);
            }
        }

        public DateTime CreatedDate { get; set; }

        public int StaffId { get; set; }

        public bool IsAprroved { get; set; } = false;

        public string Account { get; set; }

        private string _note;
        [MaxLength(255, ErrorMessage = "Ghi chú có độ dài tối đa là {1}")]
        public string Note
        {
            get { return _note; }
            set
            {
                OnPropertyChanged(ref _note, value);
            }
        }

        public virtual List<SaleBillDetailViewModel> SaleBillDetailViewModels { get; set; } = new List<SaleBillDetailViewModel>();

        public string TotalMoneyString
        {
            get
            {

                return string.Format("{0:n0}", TotalMoney);
            }
        }
        private long _customerPay = 0;
        public long CustomerPay {
            get { return _customerPay; }
            set
            {
                OnPropertyChanged(ref _customerPay, value);
            }
        }

        public long ExcessCash {
            get
            {
                var excessCash = CustomerPay - TotalMoney;
                return excessCash;
            }
            
        }

        public string ExcessCashString
        {
            get
            {
                return string.Format("{0:n0}", ExcessCash);
            }

        }

        public SaleBill MapToSaleBill()
        {
            return new SaleBill()
            {
                SaleBillId = this.SaleBillId,
                StaffId = this.StaffId,
                Discount = this.Discount,
                TotalMoney = this.TotalMoney,
                CreatedDate = this.CreatedDate,
                Note = this.Note
            };
        }
    }
}
