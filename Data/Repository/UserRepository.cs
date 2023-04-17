using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookWormDbContext _context;

        public UserRepository(BookWormDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.UserId == id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
