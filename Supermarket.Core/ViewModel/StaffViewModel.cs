using SupermarketAPI.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Core.ViewModels
{
    public class StaffViewModel : BaseViewModel
    {
        public StaffViewModel() { }

        public StaffViewModel(Staff staff)
        {
            this.StaffId = staff.StaffId;
            this.FullName = staff.FullName;
            this.Account = staff.Account;
            this.PhoneNumber = staff.PhoneNumber;
            this.StaffRole = staff.StaffRole;
            this.Note = staff.Note;
            this.IsActive = staff.IsActive;
            this.Email = staff.Email;
            this.CreatedDate = staff.CreatedDate;
        }
        public int StaffId { get; set; }

        private string _fullName;
        [Required(ErrorMessage = "Vui Lòng nhập Họ và tên")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Họ và tên cần có độ dài từ {2} đến {1} ký tự")]
        public string FullName
        {
            get { return _fullName; }
            set
            {
                OnPropertyChanged(ref _fullName, value);
            }
        }

        private string _account;
        //[Required]
        //[MaxLength(30)]
        public string Account
        {
            get { return _account; }
            set
            {
                OnPropertyChanged(ref _account, value);
            }
        }


        private string _phoneNumber;
        [MaxLength(20, ErrorMessage = "Số điện thoại có số kí tự tối đa là {1}")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                OnPropertyChanged(ref _phoneNumber, value);
            }
        }


        private string _email;
        [MaxLength(255, ErrorMessage = "Email có số kí tự tối đa là {1}")]
        public string Email
        {
            get { return _email; }
            set
            {
                OnPropertyChanged(ref _email, value);
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
        public DateTime CreatedDate { get; set; }

        private int _staffRole = (int)EStaffRole.SaleStaff;
        public int StaffRole
        {
            get { return _staffRole; }
            set
            {
                OnPropertyChanged(ref _staffRole, value);
            }
        }

        private string _password;
        [Required(ErrorMessage = "Vui Lòng mật khẩu")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Mật khẩu cần có độ dài từ {2} đến {1} ký tự")]
        public string Password
        {
            get { return _password; }
            set
            {
                OnPropertyChanged(ref _password, value);
            }
        }

        private string _note;
        [MaxLength(255, ErrorMessage = "Ghi chú có số kí tự tối đa là {1}")]
        public string Note
        {
            get { return _note; }
            set
            {
                OnPropertyChanged(ref _note, value);
            }
        }

        public Staff MapToStaff()
        {
            var staff = new Staff()
            {
                Account = this.Account,
                CreatedDate = this.CreatedDate,
                Email = this.Email,
                FullName = this.FullName,
                IsActive = this.IsActive,
                PhoneNumber = this.PhoneNumber,
                Note = this.Note,
                StaffId = this.StaffId,
                StaffRole = this.StaffRole,
            };
            return staff;
        }
    }
}
