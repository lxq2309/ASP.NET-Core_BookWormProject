namespace BookWormProject.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Thumbnails { get; set; } = null!;

    public int ViewCount { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}