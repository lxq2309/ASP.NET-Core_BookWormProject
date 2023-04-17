using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}