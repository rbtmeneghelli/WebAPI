//using WebAPI.Application.Interfaces;
using WebAPI.Domain.Enums;
using WebAPI.Domain.ExtensionMethods;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text.Encodings.Web;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Configuration.Middleware.Authentication;

public class CustomAuthorizeHandler : AuthenticationHandler<CustomMyAuthenticationSchemeOptions>
{
    private const string UNAUTHORIZED_MSG = "Caro Usuário, seu token de acesso não possui privilegios de permissão para utilizar o endpoint Requisitado";
    private const string FORBIDDEN_MSG = "Caro Usuário, seu token de acesso não possui privilegios de permissão para utilizar o endpoint do sistema ";
    private readonly IHttpContextAccessor _accessor;
    private string _currentToken;
    private IGeneralService _generalService;
    private IAccountService _accountService;

    public CustomAuthorizeHandler(
                                     IAccountService accountService,
                                     IGeneralService generalService,
                                     IHttpContextAccessor accessor,
                                     IOptionsMonitor<CustomMyAuthenticationSchemeOptions> options,
                                     ILoggerFactory logger,
                                     UrlEncoder encoder,
                                     ISystemClock clock) : base(options, logger, encoder, clock)
    {
        _accessor = accessor;
        _generalService = generalService;
        _accountService = accountService;
    }

    protected bool IsAuthenticated()
    {
        return _accessor.HttpContext.User.Identity.IsAuthenticated;
    }

    private EnumSystem GetSystemByToken()
    {
        JwtSecurityToken jwtSecurityToken = GetTokenInformations();
        Enum.TryParse<EnumSystem>(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type.Equals("system", StringComparison.OrdinalIgnoreCase)).Value, out var eSystem);
        return eSystem;
    }

    private long GetUserIdByToken()
    {
        JwtSecurityToken jwtSecurityToken = GetTokenInformations();
        return Convert.ToInt64(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "Id").Value);
    }

    private AuthenticationTicket GetAuthenticationTicket()
    {
        var credentials = _accountService.GetUserCredentialsByIdAsync(GetUserIdByToken()).GetAwaiter().GetResult();
        List<Claim> Userclaims = new List<Claim>();

        foreach (var claim in credentials.Roles)
        {
            Userclaims.Add(new Claim(claim, "read,post,read"));
        }

        var identity = new ClaimsIdentity(Userclaims, CustomMyAuthenticationSchemeOptions.SchemeName);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return ticket;
    }

    private JwtSecurityToken GetTokenInformations()
    {
        return new JwtSecurityTokenHandler().ReadJwtToken(_currentToken.Substring(_currentToken.LastIndexOf(' ') + 1));
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var endpoint = Request.HttpContext.GetEndpoint();

        if (endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null)
        {
            return AuthenticateResult.NoResult();
        }

        if (IsAuthenticated())
        {
            EnumSystem eSystem = GetSystemByToken();

            if (eSystem.Equals(EnumSystem.Default))
            {
                return AuthenticateResult.Success(GetAuthenticationTicket());
            }
        }

        return AuthenticateResult.Fail(UNAUTHORIZED_MSG);
    }

    protected override async Task HandleChallengeAsync(AuthenticationProperties authenticationProperties)
    {
        await base.HandleChallengeAsync(authenticationProperties);
        Response.ContentType = "application/json";
        Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        await Response.WriteAsync(new
        {
            Message = UNAUTHORIZED_MSG
        }.SerializeObject());
    }

    protected override async Task HandleForbiddenAsync(AuthenticationProperties authenticationProperties)
    {
        await base.HandleForbiddenAsync(authenticationProperties);
        Response.ContentType = "application/json";
        Response.StatusCode = (int)HttpStatusCode.Forbidden;
        await Response.WriteAsync(new
        {
            Message = FORBIDDEN_MSG
        }.SerializeObject());
    }
}
