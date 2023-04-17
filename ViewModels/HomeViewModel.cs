namespace BookWormProject.ViewModels
{
    public class HomeViewModel
    {
        public List<ArticleViewModel> hotArticles { get; set; }
        public List<ArticleViewModel> newArticles { get; set; }
        public List<ArticleViewModel> completedArticles { get; set; }

        public HomeViewModel(List<ArticleViewModel> hotArticles, List<ArticleViewModel> newArticles, List<ArticleViewModel> completedArticles)
        {
            this.hotArticles = hotArticles;
            this.newArticles = newArticles;
            this.completedArticles = completedArticles;
        }
    }
}