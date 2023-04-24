
using BookWormProject.Data.Services;
using BookWormProject.Utils.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class AdminController : Controller
    {
        [Role("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
