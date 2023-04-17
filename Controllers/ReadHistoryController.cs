using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class ReadHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
