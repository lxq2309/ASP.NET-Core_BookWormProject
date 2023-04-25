using BookWormProject.Data.Repository;
using BookWormProject.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;

namespace BookWormProject.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddUser(User user)
        {
            if (GetByEmail(user.Email) != null)
            {
                throw new Exception("Email already exists.");
            }

            user.Gender = false;
            user.PhoneNumber = "";
            user.Address = "";
            user.DateOfBirth = DateTime.Today;
            user.Description = "";
            user.CreatedAt = DateTime.Now;
            user.Role = 0;
            _userRepository.Add(user);
        }

        public void DeleteUser(int id)
        {
            var user = GetById(id);
            _userRepository.Delete(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User? GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public void UpdateUser(User user)
        {
            if (user.PhoneNumber == null)
            {
                user.PhoneNumber = "";
            }
            if (user.Address == null)
            {
                user.Address = "";
            }
            if (user.Avatar == null)
            {
                user.Avatar = "";
            }
            if (user.Description == null)
            {
                user.Description = "";
            }
            _userRepository.Update(user);
        }

        public void ChangePassword(User user, string newPassword)
        {
            var hashedPassword = _passwordHasher.HashPassword(null, newPassword);
            var passwordBytes = Encoding.UTF8.GetBytes(hashedPassword);
            user.Password = passwordBytes;
            _userRepository.Update(user);
        }

        public IEnumerable<User> GetUsers(int page, int pageSize)
        {
            return _userRepository.GetAll().Skip((page - 1) * pageSize).Take(pageSize);
        }

        public bool Authenticate(User? user, string password)
        {
            if (user == null)
            {
                return false;
            }

            var userPassword = Encoding.UTF8.GetString(user.Password);
            return _passwordHasher.VerifyHashedPassword(user, userPassword, password) == PasswordVerificationResult.Success;
        }

        public int GetCurrentUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            // Nếu không tìm thấy UserId, trả về giá trị mặc định (ví dụ: 0)
            return 0;
        }

        public User? GetByUserName(string userName)
        {
            return _userRepository.GetByUserName(userName);
        }

        public IEnumerable<Bookmark>? GetBookmarksForUser(int userId)
        {
            return _userRepository.GetBookmarksForUser(userId);
        }

        public IEnumerable<Comment>? GetCommentsForUser(int userId)
        {
            return _userRepository.GetCommentsForUser(userId);
        }

        public string GetRoleForUser(int userId)
        {
            if (userId == 0)
            {
                return "Guest";
            }

            string role;
            var user = GetById(userId);
            if (user.Role == 0)
            {
                role = "User";
            }
            else if (user.Role == 1)
            {
                role = "Admin";
            }
            else
            {
                role = "Other";
            }

            return role;
        }

        public IEnumerable<Article> GetArticlesForUser(int userId)
        {
            return _userRepository.GetArticlesForUser(userId);
        }
    }
}