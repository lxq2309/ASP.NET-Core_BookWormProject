using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.User
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ tài khoản")]
        public bool RememberMe { get; set; }

        public bool IsLoggedFacebook { get; set; } = false;
        public bool IsLoggedGoogle { get; set; } = false;
    }

}
