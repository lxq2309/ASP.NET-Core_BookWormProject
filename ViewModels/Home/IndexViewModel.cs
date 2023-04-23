using BookWormProject.ViewModels.Article;

namespace BookWormProject.ViewModels.Home
{
    public class IndexViewModel
    {
        public List<ArticleDetailViewModel> HotArticles { get; set; }
        public List<ArticleDetailViewModel> NewArticles { get; set; }
        public List<ArticleDetailViewModel> CompletedArticles { get; set; }
        public IndexViewModel(List<ArticleDetailViewModel> hotArticles, List<ArticleDetailViewModel> newArticles, List<ArticleDetailViewModel> completedArticles)
        {
            this.HotArticles = hotArticles;
            this.NewArticles = newArticles;
            this.CompletedArticles = completedArticles;
        }
    }
}