using Microsoft.AspNetCore.Mvc.Filters;

namespace Web_Api.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { /* Öncesi */ }
        public void OnActionExecuted(ActionExecutedContext context) { /* Sonrası */ }
    }
}
