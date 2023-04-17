using BookWormProject.Models;
using BookWormProject.Utils.Helper;

namespace BookWormProject.ViewModels
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string TimeDiff
        {
            get
            {
                return DateTimeHelper.ToTimeAgo(UpdatedAt);
            }
        }

        public DateTime UpdatedAt { get; set; }
        public bool IsCompleted {get; set;}
        public string Description { get; set; }
        public string Author { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
        public Category Category { get; set; }
        public string CoverImage { get; set; }
        public IEnumerable<Chapter>? Chapters { get; set; }
    }
}
