﻿using System.Security.Claims;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface IGeneralService
{
    string CreateJwtToken(Credentials credentials);
    Task<MemoryStream> Export2ZipAsync(string directory, EnumMemoryStreamFile typeFile = EnumMemoryStreamFile.PDF);
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
