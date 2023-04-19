using BookWormProject.Data.Services;
using BookWormProject.ViewModels.Article;
using BookWormProject.ViewModels.Genre;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IArticleService _articleService;

        public GenreController(IGenreService genreService, IArticleService articleService)
        {
            _genreService = genreService;
            _articleService = articleService;
        }

        [Route("~/the-loai/{genreId}")]
        public IActionResult Index(int genreId)
        {
            var currentGenre = _genreService.GetGenreById(genreId);
            var articles = _genreService.GetArticlesForGenre(genreId)
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
            var viewModels = new GenreIndexViewModel(currentGenre, articles);
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