using Supermarket.Core.Models;
using SupermarketAPI.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Core.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public CategoryViewModel() { }

        public CategoryViewModel(Category category)
        {
            this.CategoryId = category.CategoryId;
            this.CategoryName = category.CategoryName;
            this.Description = category.Description;
        }

        [Key]
        public int CategoryId { get; set; }

        private string _categoryName;
        [Required(ErrorMessage = "Vui lòng nhập vào tên thể loại")]
        [MaxLength(255, ErrorMessage = "Tên thể loại có độ dài tối đa là {1}")]
        public string CategoryName {
            get { return _categoryName; }
            set
            {
                OnPropertyChanged(ref _categoryName, value);
            }
        }

        private string _description;
        [MaxLength(255, ErrorMessage = "Miêu tả có độ dài tối đa là {1}")]
        public string Description
        {
            get { return _description; }
            set
            {
                OnPropertyChanged(ref _description, value);
            }
        }
    }

    
}
