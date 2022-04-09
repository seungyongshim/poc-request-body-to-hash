using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Toolkit.HighPerformance;

namespace webapi.Filter;

public class RequestHashAsyncActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                             ActionExecutionDelegate next)
    {
        var req = context.HttpContext.Request;
        req.Body.Position = 0;

        var sha = HashAlgorithm.Create("SHA512");
        var hash = await sha.ComputeHashAsync(req.Body);

        req.Headers.Add("HashSHA512", Convert.ToBase64String(hash));

        await next();
    }
}
