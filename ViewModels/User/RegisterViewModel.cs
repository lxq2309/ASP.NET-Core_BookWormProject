using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "Username không được chứa dấu cách")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không trùng khớp.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }
    }

}
