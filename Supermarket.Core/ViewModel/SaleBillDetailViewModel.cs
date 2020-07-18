using SupermarketAPI.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Core.ViewModels
{
    public class SaleBillDetailViewModel : BaseViewModel
    {
        public SaleBillDetailViewModel() { }
        public SaleBillDetailViewModel(SaleBillDetail saleBillDetail)
        {
            this.Id = saleBillDetail.Id;
            this.SaleBillId = saleBillDetail.SaleBillId;
            this.ProductId = saleBillDetail.ProductId;
            this.Price = saleBillDetail.Price;
            this.Inventory = saleBillDetail.Product.Inventory;
            this.Quantity = saleBillDetail.Quantity;
            this.TotalMoney = saleBillDetail.TotalMoney;
            this.Note = saleBillDetail.Note;
            this.Serial = saleBillDetail.Product.Serial;
            this.ProductName = saleBillDetail.Product.ProductName;


        }

        public SaleBillDetailViewModel(Product product)
        {
            this.ProductId = product.ProductId;
            this.Serial = product.Serial;
            this.ProductName = product.ProductName;
            this.Price = product.Price;
            this.Inventory = product.Inventory;
        }

        public string Id { get; set; }

        public string SaleBillId { get; set; }

        public int ProductId { get; set; }

        public string Serial { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }

        public int Inventory { get; set; }

        private int _quantity = 1;
        [Range(1, Int32.MaxValue, ErrorMessage = "Số lượng có giá trị lớn hơn 0")]
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                OnPropertyChanged(ref _quantity, value);
            }
        }

        private long _totalMoney;
        public long TotalMoney
        {
            get
            {
                return (long)Quantity * (long)Price;
            }
            set
            {
                OnPropertyChanged(ref _totalMoney, value);
            }
        }


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

        public SaleBillDetail MapToSaleBillDetail()
        {
            var result = new SaleBillDetail()
            {
                Id = this.Id != null ? this.Id : Guid.NewGuid().ToString(),
                SaleBillId = this.SaleBillId,
                ProductId = this.ProductId,
                Price = this.Price,
                TotalMoney = this.TotalMoney,
                Quantity = this.Quantity,
                Note = this.Note
            };
            return result;
        }

    }
}
