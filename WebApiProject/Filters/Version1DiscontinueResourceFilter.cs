using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiProject.Filters;

public class Version1DiscontinueResourceFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        return;
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        if (!context.HttpContext.Request.Path.Value.ToLower().Contains("v2"))
        {
            var VersionError = new { Versioning = new[] { "This version of API has expired, please use the latest version." } };
            context.Result = new BadRequestObjectResult(VersionError);
        }
    }
}
