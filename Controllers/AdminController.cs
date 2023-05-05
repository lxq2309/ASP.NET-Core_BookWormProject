
using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.Utils.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWormProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly BookWormDbContext _context;
        private readonly IUserService _userService;
        private readonly IAuthorService _authorService;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IGenreService _genreService;
        private readonly IChapterService _chapterService;


        public AdminController(BookWormDbContext context, IUserService userService, IAuthorService authorService, IArticleService articleService, ICategoryService categoryService, IGenreService genreService, IChapterService chapterService)
        {
            _context = context;
            _userService = userService;
            _authorService = authorService;
            _articleService = articleService;
            _categoryService = categoryService;
            _genreService = genreService;
            _chapterService = chapterService;
        }


        [Role("Admin")]
        public IActionResult Index()
        {
            ViewBag.ArticleNumber = _articleService.GetAllArticles().Count();
            ViewBag.CategoryNumber = _categoryService.GetAllCategories().Count();
            ViewBag.GenreNumber = _genreService.GetAllGenres().Count();
            ViewBag.UserNumber = _userService.GetAllUsers().Count();
            ViewBag.AuthorNumber = _authorService.GetAllAuthors().Count();

            return View();
        }

        public IActionResult Article()
        {
            var articles = _context.Articles.Where(x => x.IsDeleted == null).Include(a => a.Authors).Include(a => a.Category).Include(a => a.Genres).ToList();
            return View(articles);
        }

        public IActionResult Chapter(int articleId)
        {
            var chapters = _chapterService.GetChapterByArticleId(articleId).ToList();
            var article = _articleService.GetArticleById(articleId);
            ViewBag.Article = article;
            return View(chapters);
        }

        public IActionResult Author()
        {
            var author = _authorService.GetAllAuthors().ToList();
            return View(author);
        }

        public IActionResult User()
        {
            var user = _userService.GetAllUsers().ToList();
            return View(user);
        }

        public IActionResult Category()
        {
            var category = _categoryService.GetAllCategories().ToList();
            return View(category);
        }

        public IActionResult Genre()
        {
            var genre = _genreService.GetAllGenres().ToList();
            return View(genre);
        }
    }
}
