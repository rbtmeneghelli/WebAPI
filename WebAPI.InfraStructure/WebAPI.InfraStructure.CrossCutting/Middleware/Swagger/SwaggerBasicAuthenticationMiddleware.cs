using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using FastPackForShare.Extensions;

namespace WebAPI.Infrastructure.CrossCutting.Middleware.Swagger;

public sealed class SwaggerBasicAuthenticationMiddleware
{
    private readonly RequestDelegate next;

    public SwaggerBasicAuthenticationMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            string authHeader = context.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                // Pega as credenciais a partir do header do request
                var header = AuthenticationHeaderValue.Parse(authHeader);
                var inBytes = Convert.FromBase64String(header.Parameter);

                var credentials = Encoding.UTF8.GetString(inBytes).Split(':');

                var username = credentials[0];
                var password = credentials[1];

                //valida as credenciais
                if (GuardClauseExtension.IsEqualString(username, "teste") && GuardClauseExtension.IsEqualString(password,"qualquercoisa#123"))
                {
                    await next.Invoke(context).ConfigureAwait(false);
                    return;
                }
            }

            context.Response.Headers["WWW-Authenticate"] = "Basic";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else
        {
            await next.Invoke(context).ConfigureAwait(false);
        }
    }
}
