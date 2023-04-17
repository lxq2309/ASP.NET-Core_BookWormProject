using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}