using BookWormProject.Models;
using BookWormProject.Utils.Helper;

namespace BookWormProject.ViewModels.Article
{
    public class ArticleDetailViewModel
    {
        public int ArticleId { get; set; }
        public Models.User? User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TimeDiff
        {
            get
            {
                return UpdatedAt.ToTimeAgo();
            }
        }
        public int ViewCount { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsCompleted { get; set; }
        public IEnumerable<Models.Genre>? Genres { get; set; }
        public string CoverImage { get; set; }
        public IEnumerable<Models.Chapter>? Chapters { get; set; }
        public IEnumerable<Models.Author>? Authors { get; set; }
    }
}