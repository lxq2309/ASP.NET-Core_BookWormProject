using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public interface IBookmarkRepository
    {
        IEnumerable<Bookmark> GetAll();

        Bookmark GetById(int id);

        void Add(Bookmark bookmark);

        void Update(Bookmark bookmark);

        void Delete(Bookmark bookmark);
    }
}