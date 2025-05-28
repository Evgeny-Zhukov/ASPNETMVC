using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Concurrent;

namespace WebEnpoints.Filters
{
    public class ControllerRequestCounterFilter : IResultFilter
    {
        private static readonly ConcurrentDictionary<string, int> RequesCounts = new();

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (descriptor != null)
            {
                string controllerName = descriptor.ControllerName;

                int count = RequesCounts.AddOrUpdate(controllerName, 1, (_, old) => old + 1);

                context.HttpContext.Response.Headers["X-Controller-Requests"] = count.ToString();
            }
        }
        public void OnResultExecuted(ResultExecutedContext context) { }
    }
}
