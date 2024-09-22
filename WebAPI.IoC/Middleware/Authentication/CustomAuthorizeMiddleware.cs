using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WebAPI.IoC.Middleware.Authentication;

public sealed class CustomAuthorizeMiddleware : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private const string UNAUTHORIZED_MSG = "Caro Usuário, seu token de acesso não possui privilegios de permissão para utilizar o endpoint Requisitado";
    private const string FORBIDDEN_MSG = "Caro Usuário, seu token de acesso não possui privilegios de permissão para utilizar o endpoint do sistema ";
    private readonly IHttpContextAccessor _accessor;

    public CustomAuthorizeMiddleware(
                    IHttpContextAccessor accessor,
                    IOptionsMonitor<AuthenticationSchemeOptions> options,
                    ILoggerFactory logger,
                    UrlEncoder encoder,
                    ISystemClock clock) : base(options, logger, encoder, clock)
    {
        _accessor = accessor;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (IsAuthenticated())
        {
            var identity = new ClaimsIdentity(Enumerable.Empty<Claim>(), Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            await Task.CompletedTask;
            return AuthenticateResult.Success(ticket);
        }
        else
        {
            await Task.CompletedTask;
            return AuthenticateResult.Fail("Token não informado para permitir acesso aos endpoints do sistema.");
        }
    }

    protected override async Task HandleChallengeAsync(AuthenticationProperties authenticationProperties)
    {
        await base.HandleChallengeAsync(authenticationProperties);
        Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        await Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes(UNAUTHORIZED_MSG));
    }

    protected override async Task HandleForbiddenAsync(AuthenticationProperties authenticationProperties)
    {
        await base.HandleForbiddenAsync(authenticationProperties);
        Response.StatusCode = (int)HttpStatusCode.Forbidden;
        await Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes(FORBIDDEN_MSG));
    }

    protected bool IsAuthenticated()
    {
        return _accessor.HttpContext.User.Identity.IsAuthenticated;
    }
}