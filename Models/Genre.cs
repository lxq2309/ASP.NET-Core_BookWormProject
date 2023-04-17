namespace BookWormProject.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Thumbnails { get; set; } = null!;

    public int ViewCount { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}