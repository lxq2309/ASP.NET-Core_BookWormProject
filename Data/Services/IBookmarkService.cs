using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface IBookmarkService
    {
        IEnumerable<Bookmark> GetAllBookmarks();

        Bookmark GetById(int id);

        void AddBookmark(Bookmark bookmark);

        void UpdateBookmark(Bookmark bookmark);

        void DeleteBookmark(int id);
        Article? GetArticleForBookmark(int bookmarkId);
        Bookmark? GetByArticleId(int articleId);
    }
}