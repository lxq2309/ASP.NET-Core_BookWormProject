using System;
using System.Collections.Generic;

namespace BookWormProject.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
