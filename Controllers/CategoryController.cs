using BookWormProject.Data.Services;
using BookWormProject.ViewModels.Article;
using BookWormProject.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;

        public CategoryController(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }

        [Route("~/the-loai/{categoryId}")]
        public IActionResult Index(int categoryId)
        {
            var currentCategory = _categoryService.GetCategoryById(categoryId);
            var articles = _categoryService.GetArticlesForCategory(categoryId)
                                           .Select(x => new ArticleDetailViewModel()
                                           {
                                               ArticleId = x.ArticleId,
                                               Title = x.Title,
                                               CoverImage = x.CoverImage,
                                               UpdatedAt = x.UpdatedAt,
                                               Genres = _articleService.GetGenresForArticle(x.ArticleId),
                                               IsCompleted = x.IsCompleted,
                                               Chapters = _articleService.GetChaptersForArticle(x.ArticleId),
                                               Authors = _articleService.GetAuthorsForArticle(x.ArticleId)
                                           })
                                           .ToList();
            CategoryIndexViewModel viewModels = new CategoryIndexViewModel(currentCategory, articles);
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