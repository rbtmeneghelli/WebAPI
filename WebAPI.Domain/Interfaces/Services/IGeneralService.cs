using System.Security.Claims;
using FastPackForShare.Enums;
using FastPackForShare.Models;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface IGeneralService
{
    string CreateJwtToken(AuthenticationModel authenticationModel);
    Task<MemoryStream> Export2ZipAsync(string directory, EnumFile typeFile = EnumFile.Pdf);
    Task<bool> SendPushNotificationAsync(PushNotification notification, string tokenUser);
    string GenerateToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    void SaveRefreshToken(string username, string refreshToken);
    string GetRefreshToken(string username);
    void DeleteRefreshToken(string username, string refreshToken);
    string ExtractObjectInformationsByReflection(object obj);
    bool ValidateToken(string jwtToken);
    object ExtractDataToken(string token);
}
