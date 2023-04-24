using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BookWormProject.Data.Services;
using BookWormProject.Utils.Attributes;

namespace BookWormProject.Utils.Filter
{
    public class RoleFilter : IAuthorizationFilter
    {
        private readonly IUserService _userService;

        public RoleFilter(IUserService userService)
        {
            _userService = userService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var actionRole = (context.ActionDescriptor.EndpointMetadata.FirstOrDefault(m => m is RoleAttribute) as RoleAttribute)?.Role;
            if (actionRole == null)
            {
                // Không có attribute Role trên phương thức, cho phép truy cập.
                return;
            }

            // Kiểm tra quyền truy cập của người dùng.
            var userId = _userService.GetCurrentUserId();
            var userRole = _userService.GetRoleForUser(userId);
            if (userRole != actionRole)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
                return;
            }
        }
    }

}
