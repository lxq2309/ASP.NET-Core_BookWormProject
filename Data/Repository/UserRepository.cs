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
            user.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Where(x => x.IsDeleted == null);
        }

        public IEnumerable<Bookmark>? GetBookmarksForUser(int userId)
        {
            var user = _context.Users.Include(x => x.Bookmarks).FirstOrDefault(x => x.IsDeleted == null && x.UserId == userId);
            if (user != null)
            {
                return user.Bookmarks;
            }
            return null;
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(x => x.IsDeleted == null && x.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.IsDeleted == null && x.UserId == id);
        }

        public User? GetByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(x => x.IsDeleted == null && x.UserName == userName);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public IEnumerable<Comment>? GetCommentsForUser(int userId)
        {
            var user = _context.Users.Include(x => x.Comments).FirstOrDefault(x => x.IsDeleted == null && x.UserId == userId);
            if (user != null)
            {
                return user.Comments;
            }

            return null;
        }

        public IEnumerable<Article>? GetArticlesForUser(int userId)
        {
            var user = _context.Users.Include(x => x.Articles).FirstOrDefault(x => x.IsDeleted == null && x.UserId == userId);
            if (user != null)
            {
                return user.Articles;
            }
            return null;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

    }
}