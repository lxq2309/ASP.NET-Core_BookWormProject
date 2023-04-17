using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}