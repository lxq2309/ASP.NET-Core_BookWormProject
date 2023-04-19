namespace BookWormProject.DTOs
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IEnumerable<GenreDTO>? Genres { get; set; }
        public bool IsCompleted { get; set; }
        public IEnumerable<ChapterDTO>? Chapters { get; set; }
        public IEnumerable<AuthorDTO>? Authors { get; set; }

    }
}
