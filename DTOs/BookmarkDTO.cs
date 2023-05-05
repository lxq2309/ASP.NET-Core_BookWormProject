namespace BookWormProject.DTOs
{
    public class BookmarkDTO
    {
        public int? BookmarkId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; }
        public int ArticleId { get; set; }
    }
}
