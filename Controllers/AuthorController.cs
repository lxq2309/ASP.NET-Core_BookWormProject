using BookWormProject.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [Route("~/tac-gia/{id}")]
        public IActionResult Index(int id)
        {
            var currentAuthor = _authorService.GetAuthorById(id);
            return View(currentAuthor);
        }
    }
}
