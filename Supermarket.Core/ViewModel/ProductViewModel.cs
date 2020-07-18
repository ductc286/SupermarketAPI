using SupermarketAPI.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Core.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductViewModel() { }
        public ProductViewModel(Product product) 
        {
            this.ProductId = product.ProductId;
            this.CategoryId = product.CategoryId;
            this.SupplierId = product.SupplierId;
            this.ProductName = product.ProductName;
            this.Serial = product.Serial;
            this.Inventory = product.Inventory;
            this.IsActive = product.IsActive;
            this.Note = product.Note;
            this.Price = product.Price;
            this.Unit = product.Unit;
            
        }

        public int ProductId { get; set; }

        private string _serial;
        [MaxLength(255, ErrorMessage = "Serial có độ dài tối đa là {1}")]
        public string Serial {
            get { return _serial; }
            set
            {
                OnPropertyChanged(ref _serial, value);
            }
        }

        private string _productName;
        [Required(ErrorMessage = "Vui Lòng nhập tên sản phẩm")]
        [MaxLength(255, ErrorMessage = "Tên sản phẩm có độ dài tối đa là {1}")]
        public string ProductName {
            get { return _productName; }
            set
            {
                OnPropertyChanged(ref _productName, value);
            }
        }

        private int _supplierId;
        [Required(ErrorMessage = "Vui Lòng nhập mã nhà phân phối")]
        public int SupplierId
        {
            get { return _supplierId; }
            set
            {
                OnPropertyChanged(ref _supplierId, value);
            }
        }

        private int _categoryId;
        [Required(ErrorMessage = "Vui Lòng nhập mã thể loại")]
        public int CategoryId {
            get { return _categoryId; }
            set
            {
                OnPropertyChanged(ref _categoryId, value);
            }
        }

        private int _price;
        public int Price {
            get { return _price; }
            set
            {
                OnPropertyChanged(ref _price, value);
            }
        }

        private int _sold;
        public int Sold {
            get { return _sold; }
            set
            {
                OnPropertyChanged(ref _sold, value);
            }
        }

        private int _inventory;
        public int Inventory {
            get { return _inventory; }
            set
            {
                OnPropertyChanged(ref _inventory, value);
            }
        }

        private string _unit;
        [Required(ErrorMessage = "Vui Lòng nhập tên sản phẩm")]
        [MaxLength(255, ErrorMessage = "Đơn vị có độ dài tối đa là {1}")]
        public string Unit {
            get { return _unit; }
            set
            {
                OnPropertyChanged(ref _unit, value);
            }
        }

        private bool _isActive = true;
        public bool IsActive {
            get { return _isActive; }
            set
            {
                OnPropertyChanged(ref _isActive, value);
            }
        }

        private string _note;
        [MaxLength(255, ErrorMessage = "Ghi chú có độ dài tối đa là {1}")]
        public string Note {
            get { return _note; }
            set
            {
                OnPropertyChanged(ref _note, value);
            }
        }
    }
}
