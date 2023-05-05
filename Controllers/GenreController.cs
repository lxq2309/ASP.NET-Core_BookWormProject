using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.ViewModels.Category;
using BookWormProject.ViewModels.Genre;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public GenreController(IGenreService genreService, IArticleService articleService, ICategoryService categoryService)
        {
            _genreService = genreService;
            _articleService = articleService;
            _categoryService = categoryService;
        }

        [Route("~/the-loai/{genreId}")]
        public IActionResult Index(int genreId)
        {
            var currentGenre = _genreService.GetGenreById(genreId);
            return View(currentGenre);
        }


        public IActionResult Create()
        {
            ViewBag.AllCategories = _categoryService.GetAllCategories();
            return View(new GenreCreateEditViewModel());
        }

        [HttpPost]
        public IActionResult Create(GenreCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var genre = new Genre
            {
                Name = model.Name,
                Description = model.Description
            };

            // Lấy danh sách các thể loại
            if (model.Categories != null)
            {
                foreach (var categoryId in model.Categories)
                {
                    var category = _categoryService.GetCategoryById(categoryId);
                    if (category != null)
                    {
                        genre.Categories.Add(category);
                    }
                }
            }

            _genreService.AddGenre(genre);

            return RedirectToAction("Genre", "Admin");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.AllCategories = _categoryService.GetAllCategories();
            var genre = _genreService.GetGenreById(id);
            return View(new GenreCreateEditViewModel()
            {
                GenreId = genre.GenreId,
                Name = genre.Name,
                Description = genre.Description,
                SelectedCategories = _genreService.GetCategoriesForGenre(id)
            });
        }

        [HttpPost]
        public IActionResult Edit(GenreCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var genre = _genreService.GetGenreById((int)model.GenreId);
            genre.Name = model.Name;
            genre.Description = model.Description;

            _genreService.UpdateGenre(genre);
            return RedirectToAction("Genre", "Admin");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _genreService.DeleteGenre(id);
            return RedirectToAction("Genre", "Admin");
        }
    }
}