using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
