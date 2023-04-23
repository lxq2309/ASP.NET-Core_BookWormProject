using BookWormProject.Data.Services;
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
            return View(currentGenre);
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