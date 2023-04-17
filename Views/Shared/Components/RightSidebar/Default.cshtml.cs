using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

[ViewComponent(Name = "RightSidebar")]
public class RightSidebarComponent : ViewComponent
{
    private readonly IGenreService _genreService;

    public RightSidebarComponent(IGenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var genres = _genreService.GetAllGenres().OrderBy(x => x.Name).ToList();
        return View(genres);
    }
}