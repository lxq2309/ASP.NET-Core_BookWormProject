using System.Security.Claims;
using System.Text;
using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.Utils.Helper;
using BookWormProject.ViewModels.Article;
using BookWormProject.ViewModels.Bookmark;
using BookWormProject.ViewModels.Comment;
using BookWormProject.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            var viewModels = new UserIndexViewModel(currentUser, bookmarks, comments);
            return View(viewModels);
    }

    public IActionResult Details()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }

    [Route("/dang-ky")]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [Route("/dang-ky")]
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
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [Route("/dang-nhap")]
    [HttpPost]
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