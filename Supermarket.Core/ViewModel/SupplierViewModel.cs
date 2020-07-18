using SupermarketAPI.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Core.ViewModels
{
    public class SupplierViewModel : BaseViewModel
    {

        public SupplierViewModel() { }

        public SupplierViewModel(Supplier supplier)
        {
            this.SupplierId = supplier.SupplierId;
            this.SupplierName = supplier.SupplierName;
            this.Description = supplier.Description;
        }

        [Key]
        public int SupplierId { get; set; }

        private string _supplierName;
        [Required (ErrorMessage ="Vui Lòng nhập tên nhà phân phối.")]
        [MaxLength(255, ErrorMessage = "Tên nhà phân phối có độ dài tối đa là {1}")]
        public string SupplierName {
            get { return _supplierName; }
            set
            {
                OnPropertyChanged(ref _supplierName, value);
            }
        }

        private string _description;
        [MaxLength(255, ErrorMessage = "Miêu tả có độ dài tối đa là {1}")]
        public string Description {
            get { return _description; }
            set
            {
                OnPropertyChanged(ref _description, value);
            }
        }

        
    }
}
