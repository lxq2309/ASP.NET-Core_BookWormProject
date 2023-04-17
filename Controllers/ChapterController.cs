using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class ChapterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
