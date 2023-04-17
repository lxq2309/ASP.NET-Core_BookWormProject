using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
