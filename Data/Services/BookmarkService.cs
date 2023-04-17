using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IBookmarkRepository _bookmarkRepository;

        public BookmarkService(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;
        }

        public void AddBookmark(Bookmark bookmark)
        {
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

        public Bookmark GetById(int id)
        {
            return _bookmarkRepository.GetById(id);
        }

        public void UpdateBookmark(Bookmark bookmark)
        {
            _bookmarkRepository.Update(bookmark);
        }
    }
}
