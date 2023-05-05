using BookWormProject.Models;

namespace BookWormProject.Data.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        void Add(User user);

        void Update(User user);

        void Delete(User user);
        User? GetByEmail(string email);
        User? GetByUserName(string userName);
        IEnumerable<Bookmark>? GetBookmarksForUser(int userId);
        IEnumerable<Comment>? GetCommentsForUser(int userId);
        IEnumerable<Article>? GetArticlesForUser(int userId);
        Task UpdateAsync(User user);
    }
}