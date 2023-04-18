using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookWormDbContext _context;

        public AuthorRepository(BookWormDbContext context)
        {
            _context = context;
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.SingleOrDefault(x => x.AuthorId == id);
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}
