using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebMinimalAPI._2._Application.DTOS;
using WebMinimalAPI._2._Application.Interfaces;

namespace WebMinimalAPI._2._Application.Services;

public sealed class TokenService : ITokenService
{
    private readonly IOptions<JwtOptions> _jwtOptionsDTO;

    public TokenService(IOptions<JwtOptions> jwtOptionsDTO)
    {
        _jwtOptionsDTO = jwtOptionsDTO;
    }

    public Task<string> CreateAccessToken(string userName)
    {
        string[] permissions = new[] { "read_todo", "create_todo" };

        var keyBytes = Encoding.UTF8.GetBytes(_jwtOptionsDTO.Value.PrivateKey);
        var symmetricKey = new SymmetricSecurityKey(keyBytes);

        var signingCredentials = new SigningCredentials(
            symmetricKey,
            SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim("sub", userName),
            new Claim("name", userName),
            new Claim("aud", _jwtOptionsDTO.Value.Audience)
        };

        var roleClaims = permissions.Select(x => new Claim("role", x));

        claims.AddRange(roleClaims);

        var token = new JwtSecurityToken(
            issuer: _jwtOptionsDTO.Value.Issuer,
            audience: _jwtOptionsDTO.Value.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: signingCredentials);

        var rawToken = new JwtSecurityTokenHandler().WriteToken(token);
        return Task.FromResult(rawToken);
    }
}
