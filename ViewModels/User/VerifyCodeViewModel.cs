using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.User
{

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage = "Mã xác nhận là bắt buộc.")]
        public string Code { get; set; }

        public string? Email { get; set; }
    }

}
