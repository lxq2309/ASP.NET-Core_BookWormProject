using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetById(int id);
        void AddGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(int id);
    }
}
