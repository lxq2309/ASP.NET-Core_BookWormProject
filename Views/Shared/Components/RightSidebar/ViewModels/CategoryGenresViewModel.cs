using BookWormProject.Models;

namespace BookWormProject.Views.Shared.Components.RightSidebar.ViewModels
{
    public class CategoryGenresViewModel
    {
        public CategoryGenresViewModel(Category currentCategory, List<Genre> genres)
        {
            CurrentCategory = currentCategory;
            Genres = genres;
        }

        public Category CurrentCategory { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
