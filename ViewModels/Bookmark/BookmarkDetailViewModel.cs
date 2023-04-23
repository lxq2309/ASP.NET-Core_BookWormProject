namespace BookWormProject.ViewModels.Bookmark
{
    public class BookmarkDetailViewModel
    {
        public int BookmarkId { get; set; }
        public string BookmarkName { get; set; }
        public string BookmarkDescription { get; set;}
        public bool IsPublic { get; set; }
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleCoverImage { get; set; }
        public string ArticleUpdatedTimeAgo { get; set; }
        public Models.Chapter NewestChapter { get; set; }

    }
}
