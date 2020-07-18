using System.ComponentModel.DataAnnotations;

namespace Supermarket.Core.ViewModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {

        private string _password;
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu hiện tại")]
        [MaxLength(255, ErrorMessage = "Mật khẩu có độ dài tối đa là {1}")]
        public string Password
        {
            get { return _password; }
            set
            {
                OnPropertyChanged(ref _password, value);
            }
        }

        private string _newPassword;
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu mới")]
        [MaxLength(30, ErrorMessage = "Mật khẩu mới có độ dài tối đa là {1}")]
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                OnPropertyChanged(ref _newPassword, value);
            }
        }
    }
}
