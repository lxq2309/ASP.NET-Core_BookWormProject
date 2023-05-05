using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IUserService _userService;

        public BookmarkService(IBookmarkRepository bookmarkRepository, IUserService userService)
        {
            _bookmarkRepository = bookmarkRepository;
            _userService = userService;
        }

        public void AddBookmark(Bookmark bookmark)
        {
            bookmark.UserId = _userService.GetCurrentUserId();
            _bookmarkRepository.Add(bookmark);
        }

        public void DeleteBookmark(int id)
        {
            _bookmarkRepository.Delete(GetById(id));
        }

        public IEnumerable<Bookmark> GetAllBookmarks()
        {
            return _bookmarkRepository.GetAll();
        }

        public Article? GetArticleForBookmark(int bookmarkId)
        {
            return _bookmarkRepository.GetArticleForBookmark(bookmarkId);
        }

        public Bookmark GetById(int id)
        {
            return _bookmarkRepository.GetById(id);
        }

        public void UpdateBookmark(Bookmark bookmark)
        {
            _bookmarkRepository.Update(bookmark);
        }

        public Bookmark? GetByArticleId(int articleId)
        {
            var bookmark = _bookmarkRepository.GetAll().FirstOrDefault(x => x.ArticleId == articleId);
            if (bookmark != null)
            {
                return bookmark;
            }
            return null;
        }
    }
}