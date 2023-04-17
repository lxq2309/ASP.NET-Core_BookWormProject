using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class BookmarkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}