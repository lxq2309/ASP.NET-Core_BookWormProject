using System.ComponentModel.DataAnnotations;

namespace BookWormProject.ViewModels.Genre
{
    public class GenreCreateEditViewModel
    {
        [Required(ErrorMessage = "Please enter the genre's name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        public List<int> Categories { get; set; }
        public IEnumerable<Models.Category>? SelectedCategories { get; set; }
        public int? GenreId { get; set; }
    }
}
