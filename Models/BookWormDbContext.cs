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

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN-PC;Initial Catalog=BookWormDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False; MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PK__Articles__9C6270C8BD38A0EA");

            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.CoverImage)
                .HasMaxLength(255)
                .HasDefaultValueSql("('/resource/images/default_cover_image.jpg')");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Articles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Articles__UserID__4E88ABD4");

            entity.HasMany(d => d.Authors).WithMany(p => p.Articles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticlesAuthor",
                    r => r.HasOne<Author>().WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Articles___Autho__5070F446"),
                    l => l.HasOne<Article>().WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Articles___Artic__4F7CD00D"),
                    j =>
                    {
                        j.HasKey("ArticleId", "AuthorId").HasName("PK__Articles__CB6FDF09766C4C5D");
                        j.ToTable("Articles_Authors");
                        j.IndexerProperty<int>("ArticleId").HasColumnName("ArticleID");
                        j.IndexerProperty<int>("AuthorId").HasColumnName("AuthorID");
                    });

            entity.HasMany(d => d.Genres).WithMany(p => p.Articles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticlesGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Articles___Genre__52593CB8"),
                    l => l.HasOne<Article>().WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Articles___Artic__5165187F"),
                    j =>
                    {
                        j.HasKey("ArticleId", "GenreId").HasName("PK__Articles__6C5A209DBEF2F93B");
                        j.ToTable("Articles_Genres");
                        j.IndexerProperty<int>("ArticleId").HasColumnName("ArticleID");
                        j.IndexerProperty<int>("GenreId").HasColumnName("GenreID");
                    });
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Authors__70DAFC1407999989");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasDefaultValueSql("('/resource/images/default_avatar.jpg')");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => new { e.BookmarkId, e.ArticleId, e.UserId }).HasName("PK__Bookmark__60CB9551395C8273");

            entity.Property(e => e.BookmarkId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BookmarkID");
            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Article).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookmarks__Artic__534D60F1");

            entity.HasOne(d => d.User).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookmarks__UserI__5441852A");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B45B06346");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Link).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.ChapterId).HasName("PK__Chapters__0893A34A116CE2E3");

            entity.Property(e => e.ChapterId).HasColumnName("ChapterID");
            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Article).WithMany(p => p.Chapters)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Chapters__Articl__571DF1D5");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => new { e.CommentId, e.ArticleId, e.UserId }).HasName("PK__Comment__F765706A3E62F25F");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CommentID");
            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Content).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Article).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__Article__5812160E");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__UserID__59063A47");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385055E22116AC6");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACE255297F");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasDefaultValueSql("('/resource/images/default_avatar.jpg')");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
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
