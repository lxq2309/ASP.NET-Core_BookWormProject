using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookWormProject.Utils.Filter
{
    public class CurrentViewFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Đoạn code này dùng để lấy tên của view đang được sử dụng
            string currentView = context.RouteData.Values["action"].ToString();
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                controller.ViewBag.CurrentView = currentView;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Không cần thực hiện xử lý gì ở đây
        }
    }
}