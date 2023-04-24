using System.IO;
using System.Security.Claims;
using System.Text;
using BookWormProject.Utils.Attributes;
using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.Utils.Helper;
using BookWormProject.ViewModels.Bookmark;
using BookWormProject.ViewModels.Comment;
using BookWormProject.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using System.Xml.Linq;

namespace BookWormProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBookmarkService _bookmarkService;
        private readonly IArticleService _articleService;

        public UserController(IUserService userService, IBookmarkService bookmarkService, IArticleService articleService)
        {
            _userService = userService;
            _bookmarkService = bookmarkService;
            _articleService = articleService;
        }

        [Route("/tai-khoan")]
        public IActionResult Index()
        {
            var currentId = _userService.GetCurrentUserId();
            var currentUser = _userService.GetById(currentId);
            return View(currentUser);
        }

        public IActionResult GetPartialGeneralResult()
        {
            var currentUserId = _userService.GetCurrentUserId();
            var currentUser = _userService.GetById(currentUserId);
            var bookmarks = _userService.GetBookmarksForUser(currentUser.UserId).Select(x =>
            {
                var article = _bookmarkService.GetArticleForBookmark(x.BookmarkId);
                return new BookmarkDetailViewModel()
                {
                    BookmarkId = x.BookmarkId,
                    BookmarkName = x.Name,
                    BookmarkDescription = x.Description,
                    ArticleCoverImage = article.CoverImage,
                    ArticleTitle = article.Title,
                    ArticleId = article.ArticleId,
                    ArticleUpdatedTimeAgo = DateTimeHelper.ToTimeAgo(article.UpdatedAt),
                    IsPublic = x.IsPublic,
                    NewestChapter = _articleService.GetNewestChapterForArticle(article.ArticleId)
                };
            }).OrderByDescending(x => x.BookmarkId).Take(5).ToList();

            var comments = _userService.GetCommentsForUser(currentUser.UserId).Select(x =>
            {
                var article = _articleService.GetArticleById(x.ArticleId);
                return new CommentDetailViewModel()
                {
                    ArticleId = article.ArticleId,
                    ArticleTitle = article.Title,
                    ArticleCoverImage = article.CoverImage,
                    CommentId = x.CommentId,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    TimeAgo = DateTimeHelper.ToTimeAgo(x.CreatedAt)
                };
            }).OrderByDescending(x => x.CommentId).Take(10).ToList();
            var viewModels = new UserGeneralInfoViewModel(currentUser, bookmarks, comments);
            return PartialView("_PartialGeneral", viewModels);
        }

        public IActionResult GetPartialChangeInfoResult()
        {
            var currentId = _userService.GetCurrentUserId();
            var currentUser = _userService.GetById(currentId);
            var viewModels = new UserChangeInfoViewModel()
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                Gender = (currentUser.Gender == false)?"Nam":"Nữ",
                Name = currentUser.Name,
                Address = currentUser.Address,
                DateOfBirth = currentUser.DateOfBirth,
                Description = currentUser.Description,
                PhoneNumber = currentUser.PhoneNumber,
                Avatar = null

            };
            return PartialView("_PartialChangeInfo", viewModels);
        }

        public IActionResult GetPartialBookmarksResult(int? page)
        {
            var currentUser = _userService.GetById(_userService.GetCurrentUserId());
            var bookmarks = _userService.GetBookmarksForUser(currentUser.UserId).Select(x =>
            {
                var article = _bookmarkService.GetArticleForBookmark(x.BookmarkId);
                return new BookmarkDetailViewModel()
                {
                    BookmarkId = x.BookmarkId,
                    BookmarkName = x.Name,
                    BookmarkDescription = x.Description,
                    ArticleCoverImage = article.CoverImage,
                    ArticleTitle = article.Title,
                    ArticleId = article.ArticleId,
                    ArticleUpdatedTimeAgo = DateTimeHelper.ToTimeAgo(article.UpdatedAt),
                    IsPublic = x.IsPublic,
                    NewestChapter = _articleService.GetNewestChapterForArticle(article.ArticleId)
                };
            }).OrderByDescending(x => x.BookmarkId);

            int pageSize = 10; // Số lượng đối tượng trên mỗi trang
            int pageNumber = (page ?? 1); // Số trang hiện tại

            return PartialView("_PartialBookmark", bookmarks.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult GetPartialCommentsResult(int? page)
        {
            var currentUser = _userService.GetById(_userService.GetCurrentUserId());
            var comments = _userService.GetCommentsForUser(currentUser.UserId).Select(x =>
            {
                var article = _articleService.GetArticleById(x.ArticleId);
                return new CommentDetailViewModel()
                {
                    ArticleId = article.ArticleId,
                    ArticleTitle = article.Title,
                    ArticleCoverImage = article.CoverImage,
                    CommentId = x.CommentId,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    TimeAgo = DateTimeHelper.ToTimeAgo(x.CreatedAt)
                };
            }).OrderByDescending(x => x.CommentId);
            int pageSize = 10; // Số lượng đối tượng trên mỗi trang
            int pageNumber = (page ?? 1); // Số trang hiện tại

            return PartialView("_PartialComments", comments.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult GetPartialPostedArticle(int? page, int userId)
        {
            var articles = _userService.GetArticlesForUser(userId);
            int pageSize = 10; // Số lượng đối tượng trên mỗi trang
            int pageNumber = (page ?? 1); // Số trang hiện tại

            return PartialView("_PartialPostedArticle", articles.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult GetPartialChangePassword()
        {
            return PartialView("_PartialChangePassword", new ChangePasswordViewModel());
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_PartialChangePassword",model);
            }

            var currentUser = _userService.GetById(_userService.GetCurrentUserId());
            _userService.ChangePassword(currentUser, model.NewPassword);
            TempData["SuccessMessage"] = "Đổi mật khẩu thành công";
            return PartialView("_PartialChangePassword", model);
        }

        [HttpPost]
        public IActionResult Edit(UserChangeInfoViewModel model)
        {
            var id = _userService.GetCurrentUserId();
            var user = _userService.GetById(id);
            // Update thông tin user
            user.Name = model.Name;
            if (model.Gender == "Nam")
            {
                user.Gender = false;
            }
            else if (model.Gender == "Nữ")
            {
                user.Gender = true;
            }
            else
            {
                user.Gender = null;
            }
            user.DateOfBirth = model.DateOfBirth;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;
            user.Description = model.Description;

            // Nếu có Avatar mới thì lưu lại
            if (model.Avatar != null && model.Avatar.Length > 0)
            {
                string avatarPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resource", "images", "avatar");
                if (!Directory.Exists(avatarPath))
                {
                    Directory.CreateDirectory(avatarPath);
                }

                var fileName = user.UserName + Path.GetFileName(model.Avatar.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resource", "images", "avatar", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Avatar.CopyToAsync(fileStream);
                }

                user.Avatar = "/resource/images/avatar/" + fileName;
            }



            // Cập nhật thông tin user
            _userService.UpdateUser(user);

            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            return View();
        }

        [Route("/dang-ky")]
        [Role("Guest")]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [Route("/dang-ky")]
        [Role("Guest")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUserByMail = _userService.GetByEmail(model.Email);
                var existingUserByUserName = _userService.GetByUserName(model.UserName);

                if (existingUserByMail != null || existingUserByUserName != null)
                {
                    if (existingUserByMail != null)
                    {
                        ModelState.AddModelError("Email", "Email đã được sử dụng!");
                    }
                    if (existingUserByUserName != null)
                    {
                        ModelState.AddModelError("UserName", "UserName đã được sử dụng!");
                    }

                    return View(model);
                }

                var user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name
                };

                var passwordHasher = new PasswordHasher<User>();
                var hashedPassword = passwordHasher.HashPassword(null, model.Password);
                var passwordBytes = Encoding.UTF8.GetBytes(hashedPassword);

                user.Password = passwordBytes;
                _userService.AddUser(user);

                return RedirectToAction("Login");
            }

            return View(model);
        }

        [Route("/dang-nhap")]
        [Role("Guest")]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [Route("/dang-nhap")]
        [HttpPost]
        [Role("Guest")]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetByEmail(model.Email);
                if (_userService.Authenticate(user, model.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.Email),
                    };

                    var identity = new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(
                       CookieAuthenticationDefaults.AuthenticationScheme,
                       principal,
                       new AuthenticationProperties { IsPersistent = (model.RememberMe == true) });

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Sai email hoặc mật khẩu");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/dang-xuat")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}