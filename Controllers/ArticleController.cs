using BookWormProject.Data.Services;
using BookWormProject.ViewModels.Article;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [Route("~/tat-ca")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("~/p/{id}")]
        public IActionResult Details(int id)
        {
            var article = _articleService.GetArticleById(id);
            var viewModels = new ArticleDetailViewModel()
            {
                ArticleId = article.ArticleId,
                UserId = article.UserId,
                Title = article.Title,
                CoverImage = article.CoverImage,
                Description = article.Description,
                ViewCount = article.ViewCount,
                CreatedAt = article.CreatedAt,
                UpdatedAt = article.UpdatedAt,
                IsCompleted = article.IsCompleted,
                Genres = _articleService.GetGenresForArticle(id),
                Category = _articleService.GetCategoryForArticle(id),
                Chapters = _articleService.GetChaptersForArticle(id).OrderByDescending(x => x.ChapterId),
                Authors = _articleService.GetAuthorsForArticle(id)

            };
            return View(viewModels);
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


    }
}