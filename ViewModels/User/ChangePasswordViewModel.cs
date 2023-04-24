using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.User
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu mới.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Mật khẩu mới phải chứa ít nhất 8 ký tự, trong đó có ít nhất 1 chữ cái và 1 số.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng Xác nhận mật khẩu mới.")]
        [Compare("NewPassword", ErrorMessage = "Xác nhận mật khẩu mới không hợp lệ.")]
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu mới")]
        public string ConfirmNewPassword { get; set; }
    }

}
