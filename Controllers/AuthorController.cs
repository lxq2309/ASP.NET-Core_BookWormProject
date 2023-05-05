using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.ViewModels.Author;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IGithubService _githubService;

        public AuthorController(IAuthorService authorService, IGithubService githubService)
        {
            _authorService = authorService;
            _githubService = githubService;
        }

        [Route("~/tac-gia/{id}")]
        public IActionResult Index(int id)
        {
            var currentAuthor = _authorService.GetAuthorById(id);
            return View(currentAuthor);
        }

        public IActionResult Create()
        {
            return View(new AuthorCreateEditViewModel());
        }

        [HttpPost]
        public IActionResult Create(AuthorCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newAuthor = new Author()
            {
                Name = model.Name,
                Description = model.Description,
                Avatar = model.AvatarLink
            };

            if (model.AvatarFile != null && model.AvatarFile.Length > 0)
            {
                var linkImage = _githubService.UploadImage(model.AvatarFile);
                newAuthor.Avatar = linkImage;
            }


            _authorService.AddAuthor(newAuthor);
            TempData["SuccessMessage"] = "Thêm tác giả thành công";
            return RedirectToAction("Create");
        }

        public IActionResult Edit(int id)
        {
            var author = _authorService.GetAuthorById(id);
            return View(new AuthorCreateEditViewModel()
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                AvatarLink = author.Avatar,
                Description = author.Description
            });
        }

        [HttpPost]
        public IActionResult Edit(AuthorCreateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var editAuthor = _authorService.GetAuthorById(model.AuthorId);
            editAuthor.Name = model.Name;
            editAuthor.Description = model.Description;
            editAuthor.Avatar = model.AvatarLink;
            if (model.AvatarFile != null && model.AvatarFile.Length > 0)
            {
                var linkImage = _githubService.UploadImage(model.AvatarFile);
                editAuthor.Avatar = linkImage;
            }
            _authorService.UpdateAuthor(editAuthor);
            TempData["SuccessMessage"] = "Sửa thông tin tác giả thành công";
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _authorService.DeleteAuthor(id);
            return RedirectToAction("Author", "Admin");
        }
    }
}
