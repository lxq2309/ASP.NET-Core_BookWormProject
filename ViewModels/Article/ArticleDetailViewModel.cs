using BookWormProject.Models;
using BookWormProject.Utils.Helper;

namespace BookWormProject.ViewModels.Article
{
    public class ArticleDetailViewModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }

        public string TimeDiff
        {
            get
            {
                return UpdatedAt.ToTimeAgo();
            }
        }

        public DateTime UpdatedAt { get; set; }
        public bool IsCompleted { get; set; }
        public IEnumerable<Models.Genre>? Genres { get; set; }
        public string CoverImage { get; set; }
        public IEnumerable<Chapter>? Chapters { get; set; }
        public IEnumerable<Author>? Authors { get; set; }
    }
}