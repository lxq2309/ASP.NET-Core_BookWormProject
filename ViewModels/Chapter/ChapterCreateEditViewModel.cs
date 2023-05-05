namespace BookWormProject.ViewModels.Chapter
{
    public class ChapterCreateEditViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Index { get; set; }
        public int ArticleId { get; set; }
        public int ChapterId { get; set; }
    }
}
