using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.Author
{
    public class AuthorCreateEditViewModel
    {
        [Required(ErrorMessage = "Please enter the author's name")]
        public string Name { get; set; }
        public string? AvatarLink { get; set; }
        public IFormFile? AvatarFile { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
