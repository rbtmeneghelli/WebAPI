using Microsoft.AspNetCore.Authentication.BearerToken;
using System.Security.Claims;
using WebMinimalAPI._2._Application.Interfaces;

namespace WebMinimalAPI._1._Api.Endpoints;

public static class AccountEndpoints
{
    public static void Map(WebApplication app)
    {
        var accountApi = app.MapGroup("/accounts").WithTags("Accounts");

        accountApi.MapPost("/loginBearerToken", async (string username) =>
        {
            var claimsPrincipal = new ClaimsPrincipal(
               new ClaimsIdentity(
                   new[] { new Claim(ClaimTypes.Name, username) },
                   BearerTokenDefaults.AuthenticationScheme
               )
           );

            return Results.SignIn(claimsPrincipal);
        });

        accountApi.MapPost("/loginJwtBearerToken", async (string username, ITokenService tokenService) =>
        {
            var accessToken = await tokenService.CreateAccessToken(username);
            return Results.Ok(new
            {
                access_token = accessToken,
                expiration = TimeSpan.FromSeconds(3600),
                type = "JWT Bearer Token"
            });
        });
    }
}
