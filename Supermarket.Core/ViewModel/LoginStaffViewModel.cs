using System.ComponentModel.DataAnnotations;

namespace Supermarket.Core.ViewModels
{

    public class LoginStaffViewModel : BaseViewModel
    {
        private string _account;
        [Required (ErrorMessage = "Vui lòng nhập Account")]
        [MaxLength(30, ErrorMessage = "Tài khoản có độ dài tối đa là {1}")]
        public string Account
        {
            get { return _account; }
            set
            {
                OnPropertyChanged(ref _account, value);
            }
        }

        private string _password;
        [Required(ErrorMessage = "Vui lòng nhập Password")]
        [MaxLength(255, ErrorMessage = "Mật khẩu có độ dài tối đa là {1}")]
        public string Password { 
            get { return _password; }
            set
            {
                OnPropertyChanged(ref _password, value);
            }
        }
    }
}
