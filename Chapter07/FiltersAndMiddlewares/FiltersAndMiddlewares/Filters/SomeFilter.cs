using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersAndMiddlewares.Filters
{
    public class SomeFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something.
        }
    }
}
