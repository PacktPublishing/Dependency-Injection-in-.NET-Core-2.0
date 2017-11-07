using FiltersAndMiddlewares.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersAndMiddlewares.Filters
{
    public class SomeGlobalFilter : IActionFilter
    {
        public SomeGlobalFilter(ISomeService service)
        {
            // Do something with the service.
        }

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
