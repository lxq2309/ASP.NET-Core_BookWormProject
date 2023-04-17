using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookWormProject.Models;

public partial class BookWormDbContext : DbContext
{
    public BookWormDbContext()
    {
    }

    public BookWormDbContext(DbContextOptions<BookWormDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<ReadHistory> ReadHistories { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN-PC;Initial Catalog=BookWormDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PK__Articles__9C6270C878B0A838");

            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CoverImage).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Category).WithMany(p => p.Articles)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Articles__Catego__2F10007B");

            entity.HasOne(d => d.User).WithMany(p => p.Articles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Articles__UserID__300424B4");

            entity.HasMany(d => d.Genres).WithMany(p => p.Articles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticlesGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Articles___Genre__3E52440B"),
                    l => l.HasOne<Article>().WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Articles___Artic__3D5E1FD2"),
                    j =>
                    {
                        j.HasKey("ArticleId", "GenreId").HasName("PK__Articles__6C5A209D401D8489");
                        j.ToTable("Articles_Genres");
                        j.IndexerProperty<int>("ArticleId").HasColumnName("ArticleID");
                        j.IndexerProperty<int>("GenreId").HasColumnName("GenreID");
                    });
        });

        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => new { e.BookmarkId, e.ArticleId }).HasName("PK__Bookmark__CDDC1D9D4C187FA2");

            entity.Property(e => e.BookmarkId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BookmarkID");
            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Tags).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Article).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookmarks__Artic__398D8EEE");

            entity.HasOne(d => d.User).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookmarks__UserI__3A81B327");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B4EF854FD");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Thumbnails).HasMaxLength(255);

            entity.HasMany(d => d.Genres).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoriesGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Categorie__Genre__2C3393D0"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Categorie__Categ__2B3F6F97"),
                    j =>
                    {
                        j.HasKey("CategoryId", "GenreId").HasName("PK__Categori__E9316A7E611E0314");
                        j.ToTable("Categories_Genres");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("CategoryID");
                        j.IndexerProperty<int>("GenreId").HasColumnName("GenreID");
                    });
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.ChapterId).HasName("PK__Chapters__0893A34A505051F8");

            entity.Property(e => e.ChapterId).HasColumnName("ChapterID");
            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Article).WithMany(p => p.Chapters)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Chapters__Articl__32E0915F");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385055E604037B5");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Thumbnails).HasMaxLength(255);
        });

        modelBuilder.Entity<ReadHistory>(entity =>
        {
            entity.HasKey(e => e.WatchedAt).HasName("PK__ReadHist__C5EA1BDB7B560FA2");

            entity.Property(e => e.WatchedAt).HasColumnType("datetime");
            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Article).WithMany(p => p.ReadHistories)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReadHisto__Artic__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.ReadHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReadHisto__UserI__4222D4EF");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => new { e.ReviewId, e.ArticleId }).HasName("PK__Review__ED7A5EA2982C846B");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ReviewID");
            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Article).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__ArticleI__35BCFE0A");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__UserID__36B12243");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC052E767D");

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456D8DF4032").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
