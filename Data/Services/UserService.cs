using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(GetById(id));
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
    }
}