using BookWormProject.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Views.Shared.Components.MenuAccount
{
    [ViewComponent(Name = "MenuAccount")]
    public class MenuAccountComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public MenuAccountComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentId = _userService.GetCurrentUserId();
            var currentUser = _userService.GetById(currentId);
            return View(currentUser);
        }
    }
}
