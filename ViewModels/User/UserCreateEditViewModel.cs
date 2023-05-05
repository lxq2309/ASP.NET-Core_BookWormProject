using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.User
{
    public class UserCreateEditViewModel
    {
        [Required]
        public string UserName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
