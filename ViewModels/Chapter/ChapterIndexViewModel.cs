using BookWormProject.ViewModels.Article;

namespace BookWormProject.ViewModels.Chapter
{
    public class ChapterIndexViewModel
    {
        public Models.Article? ParentArticle { get; set; }
        public Models.Chapter? CurrentChapter { get; set; }
        public Models.Chapter? NextChapter { get; set; }
        public Models.Chapter? PreviousChapter { get; set; }
        public IEnumerable<Models.Chapter>? Chapters { get; set; }
    }
}
