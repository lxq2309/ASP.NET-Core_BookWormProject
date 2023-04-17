using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}