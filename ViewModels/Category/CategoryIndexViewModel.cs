using BookWormProject.ViewModels.Article;
namespace BookWormProject.ViewModels.Category
{
    public class CategoryIndexViewModel
    {
        public Models.Category CurrentCategory { get; set; }
        public List<ArticleDetailViewModel> Articles { get; set; }

        public CategoryIndexViewModel(Models.Category currentCategory, List<ArticleDetailViewModel> articles)
        {
            CurrentCategory = currentCategory;
            Articles = articles;
        }
    }
}
