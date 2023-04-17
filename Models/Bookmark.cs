namespace BookWormProject.Models;

public partial class Bookmark
{
    public int BookmarkId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsPublic { get; set; }

    public string Tags { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public int ArticleId { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}