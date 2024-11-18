using Microsoft.AspNetCore.Http;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Infrastructure.CrossCutting.Middleware.Swagger;

public sealed class SwaggerAuthorizedMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IIpAddressService _ipAddressService;

    public SwaggerAuthorizedMiddleware(RequestDelegate next, IIpAddressService ipAddressService)
    {
        _next = next;
        _ipAddressService = ipAddressService;
    }

    public async Task Invoke(HttpContext context)
    {
        var remoteIp = context.Connection.RemoteIpAddress;

        if(_ipAddressService.IsIPAddressBlocked(remoteIp))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return;
        }

        else if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await _next.Invoke(context);
    }
}
