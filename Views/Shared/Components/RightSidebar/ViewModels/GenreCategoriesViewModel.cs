using BookWormProject.Models;

namespace BookWormProject.Views.Shared.Components.RightSidebar.ViewModels
{
    public class GenreCategoriesViewModel
    {
        public GenreCategoriesViewModel(Genre currentGenre, List<Category> categories)
        {
            CurrentGenre = currentGenre;
            Categories = categories;
        }

        public Genre CurrentGenre { get; set; }
        public List<Category> Categories { get; set; }

    }
}
