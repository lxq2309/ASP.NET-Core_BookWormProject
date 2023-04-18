using System;
using System.Collections.Generic;

namespace BookWormProject.Models;

public partial class Chapter
{
    public int ChapterId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int Index { get; set; }

    public int ViewCount { get; set; }

    public int ArticleId { get; set; }

    public virtual Article Article { get; set; } = null!;
}
