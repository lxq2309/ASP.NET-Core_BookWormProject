using BookWormProject.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("~/danh-muc/{categoryId}")]
        public IActionResult Index(int categoryId)
        {
            var currentCategory = _categoryService.GetCategoryById(categoryId);
            return View(currentCategory);
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