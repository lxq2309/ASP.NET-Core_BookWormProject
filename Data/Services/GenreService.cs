using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenresRepository _genresRepository;

        public GenreService(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }

        public void AddGenre(Genre genre)
        {
            _genresRepository.Add(genre);
        }

        public void DeleteGenre(int id)
        {
            _genresRepository.Delete(GetById(id));
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genresRepository.GetAll();
        }

        public Genre GetById(int id)
        {
            return _genresRepository.GetById(id);
        }

        public void UpdateGenre(Genre genre)
        {
            _genresRepository.Update(genre);
        }
    }
}
