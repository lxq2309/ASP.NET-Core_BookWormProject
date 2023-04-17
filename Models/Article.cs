namespace BookWormProject.Models;

public partial class Article
{
    public int ArticleId { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CoverImage { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public int ViewCount { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

    public virtual ICollection<ReadHistory> ReadHistories { get; set; } = new List<ReadHistory>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}