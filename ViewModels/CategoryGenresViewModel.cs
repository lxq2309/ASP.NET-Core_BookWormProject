using BookWormProject.Models;

namespace BookWormProject.ViewModels
{
    public class CategoryGenresViewModel
    {
        public Category category { get; set; }
        public List<Genre> genres { get; set; }

        public CategoryGenresViewModel(Category category, List<Genre> genres)
        {
            this.category = category;
            this.genres = genres;
        }
    }
}
