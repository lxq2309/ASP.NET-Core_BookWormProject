using System;
using System.Collections.Generic;

namespace BookWormProject.Models;

public partial class ReadHistory
{
    public int UserId { get; set; }

    public int ArticleId { get; set; }

    public DateTime WatchedAt { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
