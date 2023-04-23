namespace BookWormProject.ViewModels.Comment
{
    public class CommentDetailViewModel
    {
        public int CommentId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Content { get; set; }
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleCoverImage { get; set; }
        public string TimeAgo { get; set; }
    }
}
