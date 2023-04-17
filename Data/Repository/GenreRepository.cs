using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public class GenreRepository : IGenresRepository
    {
        private readonly BookWormDbContext _context;

        public GenreRepository(BookWormDbContext context)
        {
            _context = context;
        }

        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void Delete(Genre genre)
        {
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public Genre GetById(int id)
        {
            return _context.Genres.SingleOrDefault(x => x.GenreId == id);
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }
    }
}