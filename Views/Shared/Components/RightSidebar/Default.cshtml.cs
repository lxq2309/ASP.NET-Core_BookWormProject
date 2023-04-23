using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.Views.Shared.Components.RightSidebar.ViewModels;
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
            case "Category":
                var currentCategory = (Category)data;
                var genres = _categoryService.GetGenresForCategory(currentCategory.CategoryId).ToList();
                ViewBag.CategoryGenres = new CategoryGenresViewModel(currentCategory, genres);
                break;
            case "Genre":
                var currentGenre = (Genre)data;
                var categories = _genreService.GetCategoriesForGenre(currentGenre.GenreId).ToList();
                ViewBag.GenreCategories = new GenreCategoriesViewModel(currentGenre, categories);
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