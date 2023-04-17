using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public interface IGenresRepository
    {
        IEnumerable<Genre> GetAll();
        Genre GetById(int id);
        void Add(Genre genre);
        void Update(Genre genre);
        void Delete(Genre genre);
    }
}
