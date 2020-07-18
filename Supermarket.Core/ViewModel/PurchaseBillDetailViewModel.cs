using SupermarketAPI.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Core.ViewModels
{
    public class PurchaseBillDetailViewModel : BaseViewModel
    {
        public PurchaseBillDetailViewModel() { }
        public PurchaseBillDetailViewModel(PurchaseBillDetail purchaseBillDetail)
        {
            Id = purchaseBillDetail.Id != null ? purchaseBillDetail.Id : Guid.NewGuid().ToString();
            PurchaseBillId = purchaseBillDetail.PurchaseBillId;
            ProductId = purchaseBillDetail.ProductId;
            Serial = purchaseBillDetail.Product.Serial;
            ProductName = purchaseBillDetail.Product.ProductName;
            Quantity = purchaseBillDetail.Quantity;
            Inventory = purchaseBillDetail.Product.Inventory;
            Price = purchaseBillDetail.Price;
            //TotalMoney = purchaseBillDetail.TotalMoney;
            Note = purchaseBillDetail.Note;
        }

        public PurchaseBillDetailViewModel(Product product)
        {
            ProductId = product.ProductId;
            Serial = product.Serial;
            ProductName = product.ProductName;
            Inventory = product.Inventory;
            Price = product.Price;
        }

        [Key]
        [MaxLength(255)]
        public string Id { get; set; }

        [MaxLength(30)]
        public string PurchaseBillId { get; set; }

        public int ProductId { get; set; }

        public string Serial { get; set; }

        public string ProductName { get; set; }

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

        public int Inventory { get; set; }

        public int Price { get; set; }

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
        [MaxLength(3)]
        public string Note
        {
            get { return _note; }
            set
            {
                OnPropertyChanged(ref _note, value);
            }
        }

        ////Map to other object
        public PurchaseBillDetail MapToPurchaseBillDetail()
        {
            var result = new PurchaseBillDetail()
            {
                Id = this.Id != null ? this.Id : Guid.NewGuid().ToString(),
                ProductId = this.ProductId,
                Price = this.Price,
                Quantity = this.Quantity,
                TotalMoney = this.TotalMoney,
                PurchaseBillId = this.PurchaseBillId,
                Note = this.Note
            };
            return result;
        }
    }

}
