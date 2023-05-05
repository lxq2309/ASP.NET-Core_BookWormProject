using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.Category
{
    public class CategoryCreateEditViewModel
    {
        [Required(ErrorMessage = "Please enter the genre's name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        public List<int> Genres { get; set; }
        public IEnumerable<Models.Genre>? SelectedGenres { get; set; }
        public int? CategoryId { get; set; }
    }
}
