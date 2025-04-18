using Microsoft.AspNetCore.Http;

namespace WebAPI.Infrastructure.CrossCutting.Middleware.Swagger;

public sealed class SwaggerAuthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public SwaggerAuthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var remoteIp = context.Connection.RemoteIpAddress;

        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await _next.Invoke(context);
    }
}
