using BookWormProject.Models;
using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.Article
{
    public class ArticleCreateEditViewModel
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please select at least one genre.")]
        public List<int> Genres { get; set; }

        [Required(ErrorMessage = "Please select at least one author.")]
        public List<int> Authors { get; set; }


        [Required]
        public bool IsCompleted { get; set; }

        public string? AvatarLink { get; set; }
        public IFormFile? AvatarFile { get; set; }

        public IEnumerable<Models.Category>? ListCategory { get; set; }
        public IEnumerable<Models.Genre>? ListGenre { get; set; }
        public IEnumerable<Models.Author>? ListAuthor { get; set; }
        public IEnumerable<Models.Genre>? SelectedGenres { get; set; }
        public IEnumerable<Models.Author>? SelectedAuthors { get; set; }
        public int? ArticleId { get; set; }
    }
}
