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
using Microsoft.AspNetCore.Authentication.Facebook;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.AspNetCore.Authentication.Google;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Caching.Memory;

namespace BookWormProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBookmarkService _bookmarkService;
        private readonly IArticleService _articleService;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _cache;

        public UserController(IUserService userService, IBookmarkService bookmarkService, IArticleService articleService, IEmailService emailService, IMemoryCache cache)
        {
            _userService = userService;
            _bookmarkService = bookmarkService;
            _articleService = articleService;
            _emailService = emailService;
            _cache = cache;
        }

        [Route("/tai-khoan/{id?}")]
        public IActionResult Index(int? id)
        {
            var currentId = _userService.GetCurrentUserId();
            var currentUser = _userService.GetById(currentId);
            var targetUser = (id == null) ? currentUser : _userService.GetById((int)id);
            var viewModels = new UserIndexViewModel()
            {
                CurrentUser = currentUser,
                TargetUser = targetUser,
                IsMyAccount = currentUser.UserId == targetUser.UserId
            };
            return View(viewModels);
        }

        public IActionResult GetPartialGeneralResult(int id)
        {
            var currentUser = _userService.GetById(id);
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
            viewModels.IsMyAccount = id == _userService.GetCurrentUserId();
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
                Gender = (currentUser.Gender == false) ? "Nam" : "Nữ",
                Name = currentUser.Name,
                Address = currentUser.Address,
                DateOfBirth = currentUser.DateOfBirth,
                Description = currentUser.Description,
                PhoneNumber = currentUser.PhoneNumber,
                Avatar = null

            };
            return PartialView("_PartialChangeInfo", viewModels);
        }

        public IActionResult GetPartialBookmarksResult(int? page, int id)
        {
            var currentUser = _userService.GetById(id);
            var bookmarks = _userService.GetBookmarksForUser(id).Select(x =>
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

            var pagedBookmarks = bookmarks.ToPagedList(pageNumber, pageSize);
            var isMyAccount = id == _userService.GetCurrentUserId();
            var viewModels = new UserBookmarksViewModel()
            {
                PagedBookmarks = pagedBookmarks,
                IsMyAccount = isMyAccount
            };
            return PartialView("_PartialBookmark" ,viewModels);
        }

        public IActionResult GetPartialCommentsResult(int? page, int id)
        {
            var comments = _userService.GetCommentsForUser(id).Select(x =>
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

            var pagedComments = comments.ToPagedList(pageNumber, pageSize);
            var isMyAccount = id == _userService.GetCurrentUserId();
            var viewModels = new UserCommentsViewModel()
            {
                PagedComments = pagedComments,
                IsMyAccount = isMyAccount
            };
            return PartialView("_PartialComments", viewModels);
        }

        public IActionResult GetPartialPostedArticle(int? page, int id)
        {
            var articles = _userService.GetArticlesForUser(id);
            int pageSize = 10; // Số lượng đối tượng trên mỗi trang
            int pageNumber = (page ?? 1); // Số trang hiện tại

            return PartialView("_PartialPostedArticle", articles.ToPagedList(pageNumber, pageSize));
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
                return PartialView("_PartialChangePassword", model);
            }

            var currentUser = _userService.GetById(_userService.GetCurrentUserId());
            _userService.ChangePassword(currentUser, model.NewPassword);
            TempData["SuccessMessage"] = "Đổi mật khẩu thành công";
            return PartialView("_PartialChangePassword", model);
        }

        [HttpPost]
        public IActionResult Edit(UserChangeInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_PartialChangeInfo", model);
            }
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
            TempData["SuccessMessage"] = "Cập nhật thông tin thành công";

            return PartialView("_PartialChangeInfo", model);
        }

        [Route("/dang-ky")]
        [Role("Guest")]
        public IActionResult Register()
        {
            var registerViewModels = new RegisterViewModel();

            // Lấy dữ liệu từ TempData
            var thirdLoginDataJson = TempData["ThirdLoginData"] as string;
            // Nếu có dữ liệu từ Facebook, tiến hành gán sẵn dữ liệu cho người dùng
            if (!string.IsNullOrEmpty(thirdLoginDataJson))
            {
                // Chuyển đổi chuỗi JSON thành đối tượng thirdLoginData
                var thirdLoginData = JsonConvert.DeserializeObject<dynamic>(thirdLoginDataJson);

                // Gán giá trị vào view model
                registerViewModels.Name = thirdLoginData.Name;
                registerViewModels.Email = thirdLoginData.Email;
                // Thông báo cho người dùng biết đây là lần đầu họ đăng nhập bằng Facebook/Google nên phải đăng ký
                TempData["Notification"] =
                    "Đây là lần đầu bạn đăng nhập, vui lòng đăng ký để tiếp tục nhé";
                // Khoá Email input để người dùng không thể thay đổi được email
                TempData["LockEmail"] = true;
            }
            return View(registerViewModels);
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
                if (model.IsLoggedFacebook || model.IsLoggedGoogle || _userService.Authenticate(user, model.Password))
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

        [Route("/facebook-login")]
        [Role("Guest")]
        public IActionResult FacebookLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("FacebookResponse") };
            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }

        [Route("/facebook-response")]
        [Role("Guest")]
        public async Task<IActionResult> FacebookResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims;

            // Tạo đối tượng Anonymous và gán giá trị
            var ThirdLoginData = new
            {
                Name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
            };

            var user = _userService.GetByEmail(ThirdLoginData.Email);
            if (user != null)
            {
                // Nếu user đã tồn tại thì đăng nhập và trả về trang chủ
                var loginViewModel = new LoginViewModel
                {
                    Email = user.Email,
                    IsLoggedFacebook = true
                };
                return Login(loginViewModel);
            }

            // Lưu dữ liệu vào TempData để gửi cho action khác
            TempData["ThirdLoginData"] = JsonConvert.SerializeObject(ThirdLoginData);

            // Nếu chưa tồn tại thì đăng ký mới
            return RedirectToAction("Register");
        }

        [Route("/google-login")]
        [Role("Guest")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("/google-response")]
        [Role("Guest")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims;

            // Tạo đối tượng Anonymous và gán giá trị
            var thirdLoginData = new
            {
                Name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
            };

            var user = _userService.GetByEmail(thirdLoginData.Email);
            if (user != null)
            {
                // Nếu user đã tồn tại thì đăng nhập và trả về trang chủ
                var loginViewModel = new LoginViewModel
                {
                    Email = user.Email,
                    IsLoggedGoogle = true
                };
                return Login(loginViewModel);
            }

            // Lưu dữ liệu vào TempData để gửi cho action khác
            TempData["ThirdLoginData"] = JsonConvert.SerializeObject(thirdLoginData);

            // Nếu chưa tồn tại thì đăng ký mới
            return RedirectToAction("Register");
        }

        [Route("/quen-mat-khau")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("/quen-mat-khau")]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra email người dùng đã tồn tại trong hệ thống hay chưa
                var user = _userService.GetByEmail(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Email không tồn tại trong hệ thống.");
                    return View(model);
                }

                // Tạo mã xác nhận ngẫu nhiên
                var token = StringHelper.RandomString(10);

                // Lưu mã xác nhận vào Cache
                _cache.Set(token, user.UserId, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));

                // Gửi email chứa mã xác nhận đến email người dùng
                await _emailService.SendCodeAsync(user.Email, token);

                // Chuyển hướng đến trang nhập mã xác nhận
                return RedirectToAction("VerifyCode");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult VerifyCode()
        {
            return View(new VerifyCodeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Lấy mã xác nhận từ Cache
                var userId = _cache.Get<int>(model.Code);

                // Kiểm tra mã xác nhận có hợp lệ hay không
                if (userId == 0)
                {
                    ModelState.AddModelError("", "Mã xác nhận không hợp lệ hoặc đã hết hạn.");
                    return View(model);
                }

                // Hợp lệ, gửi mật khẩu mới vào email cho người dùng
                string newPassword = StringHelper.RandomString(20);
                var user = _userService.GetById(userId);
                _userService.ChangePassword(user, newPassword);
                _emailService.SendPasswordAsync(user.Email, newPassword);

                // Chuyển đến trang đăng nhập và gửi thông báo check mail để lấy mật khẩu
                TempData["Notification"] = "Vui lòng kiểm tra email để nhận mật khẩu mới";
                return RedirectToAction("Login");
            }

            return View(model);
        }





    }
}