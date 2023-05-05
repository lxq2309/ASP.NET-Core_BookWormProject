using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();

        User GetById(int id);

        void AddUser(User user);

        void UpdateUser(User user);
        Task UpdateUserAsync(User user);
        public void ChangePassword(User user, string newPassword);

        void DeleteUser(int id);
        public User? GetByEmail(string email);
        public User? GetByUserName(string userName);
        public IEnumerable<User> GetUsers(int page, int pageSize);
        public bool Authenticate(User? user, string password);
        public int GetCurrentUserId();
        public IEnumerable<Bookmark>? GetBookmarksForUser(int userId);
        public IEnumerable<Comment>? GetCommentsForUser(int userId);
        public string GetRoleForUser(int userId);
        public IEnumerable<Article>? GetArticlesForUser(int userId);
    }
}