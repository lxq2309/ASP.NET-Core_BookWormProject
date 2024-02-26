using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookWormProject.Utils.Filter
{
    public class CurrentActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Đoạn code này dùng để lấy tên của action đang được thực thi
            string currentAction = context.RouteData.Values["action"].ToString();

            // Lưu tên action vào ViewBag
            if (context.Controller is Controller controller)
            {
                controller.ViewBag.CurrentAction = currentAction;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Không cần thực hiện xử lý gì ở đây
        }
    }
}
