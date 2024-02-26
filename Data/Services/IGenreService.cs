using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();

        Genre GetGenreById(int id);

        void AddGenre(Genre genre);

        void UpdateGenre(Genre genre);

        void DeleteGenre(int id);
        IEnumerable<Article>? GetArticlesForGenre(int id);
    }
}