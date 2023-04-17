using BookWormProject.Data.Services;
using Microsoft.AspNetCore.Mvc;

[ViewComponent(Name = "MenuCategories")]
public class MenuCategoriesComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public MenuCategoriesComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = _categoryService.GetAllCategories().OrderBy(x => x.Name).ToList();
        return View(categories);
    }
}