using BookWormProject.ViewModels.Article;

namespace BookWormProject.ViewModels.Genre
{
    public class GenreIndexViewModel
    {
        public Models.Genre CurrentGenre { get; set; }
        public List<ArticleDetailViewModel> Articles { get; set; }
        public GenreIndexViewModel(Models.Genre currentGenre, List<ArticleDetailViewModel> articles)
        {
            CurrentGenre = currentGenre;
            Articles = articles;
        }
    }
}
