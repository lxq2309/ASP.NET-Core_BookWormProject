using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.User
{
    public class UserChangeInfoViewModel
    {
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Địa chỉ email")]
        public string Email { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }


        [Display(Name = "Giới tính")]
        public string? Gender { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Avatar")]
        public IFormFile? Avatar { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }


        [Display(Name = "Giới thiệu")]
        public string? Description { get; set; }
    }
}
