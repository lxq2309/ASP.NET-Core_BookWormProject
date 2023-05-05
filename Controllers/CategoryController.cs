using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IGenreService _genreService;


        public CategoryController(ICategoryService categoryService, IGenreService genreService)
        {
            _categoryService = categoryService;
            _genreService = genreService;
        }

        [Route("~/danh-muc/{categoryId}")]
        public IActionResult Index(int categoryId)
        {
            var currentCategory = _categoryService.GetCategoryById(categoryId);
            return View(currentCategory);
        }


        public IActionResult Create()
        {
            ViewBag.AllGenres = _genreService.GetAllGenres();
            return View(new CategoryCreateEditViewModel());
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category
            {
                Name = model.Name,
                Description = model.Description
            };

            // Lấy danh sách các thể loại
            if (model.Genres != null)
            {
                foreach (var genreId in model.Genres)
                {
                    var genre = _genreService.GetGenreById(genreId);
                    if (genre != null)
                    {
                        category.Genres.Add(genre);
                    }
                }
            }

            _categoryService.AddCategory(category);

            return RedirectToAction("Category", "Admin");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.AllGenres = _genreService.GetAllGenres();
            var category = _categoryService.GetCategoryById(id);
            return View(new CategoryCreateEditViewModel()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                SelectedGenres = _categoryService.GetGenresForCategory(id)
            });
        }

        [HttpPost]
        public IActionResult Edit(CategoryCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = _categoryService.GetCategoryById((int)model.CategoryId);
            category.Name = model.Name;
            category.Description = model.Description;

            _categoryService.UpdateCategory(category);

            return RedirectToAction("Category", "Admin");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Category", "Admin");
        }
    }
}