namespace BookWormProject.Models;

public partial class ReadHistory
{
    public DateTime WatchedAt { get; set; }

    public int ArticleId { get; set; }

    public int UserId { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}