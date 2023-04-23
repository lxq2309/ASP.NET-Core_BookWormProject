using BookWormProject.Models;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Bookmark>? GetBookmarksForUser(int userId)
        {
            var user = _context.Users.Include(x => x.Bookmarks).FirstOrDefault(x => x.UserId == userId);
            if (user != null)
            {
                return user.Bookmarks;
            }
            return null;
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(x => x.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.UserId == id);
        }

        public User? GetByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public IEnumerable<Comment>? GetCommentsForUser(int userId)
        {
            var user = _context.Users.Include(x => x.Comments).FirstOrDefault(x => x.UserId == userId);
            if (user != null)
            {
                return _context.Comments;
            }

            return null;
        }
    }
}