using System;
using System.Collections.Generic;

namespace BookWormProject.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Avatar { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int Role { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual ICollection<ReadHistory> ReadHistories { get; set; } = new List<ReadHistory>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
