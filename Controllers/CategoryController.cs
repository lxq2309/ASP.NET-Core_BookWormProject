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
                Link = model.Link,
                Description = model.Description
            };

            _categoryService.AddCategory(category);

            return RedirectToAction("Category", "Admin");
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return View(new CategoryCreateEditViewModel()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Link = category.Link,
                Description = category.Description,
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
            category.Link = model.Link;
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