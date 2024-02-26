using BookWormProject.Data.Services;
using BookWormProject.Models;
using Microsoft.AspNetCore.Mvc;

[ViewComponent(Name = "RightSidebar")]
public class RightSidebarComponent : ViewComponent
{
    private readonly IGenreService _genreService;
    private readonly ICategoryService _categoryService;

    public RightSidebarComponent(IGenreService genreService, ICategoryService categoryService)
    {
        _genreService = genreService;
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync(object data)
    {
        switch (ViewBag.CurrentController)
        {
            case "Home":
                ViewBag.AllGenres = _genreService.GetAllGenres();
                break;
            case "Genre":
                var currentGenre = (Genre)data;
                ViewBag.CurrentGenre = currentGenre;
                break;
            case "Author":
                var currentAuthor = (Author)data;
                ViewBag.CurrentAuthor = currentAuthor;
                break;
            default:
                break;
        }

        return View();
    }
}