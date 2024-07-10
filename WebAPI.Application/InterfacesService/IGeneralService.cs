namespace WebAPI.Application.Interfaces;

public interface IGeneralService
{
    string CreateJwtToken(Credentials credentials);
    Task<RequestData> RequestDataToExternalAPIAsync(string url);
    Task<RequestData> RequestLoginAsync(string url, string key = "");
    Task<bool> RunSqlProcedureAsync(string procName, string paramName, string paramValue);
    Task<bool> RunSqlBackupAsync(string directory);
    Task<MemoryStream> Export2ZipAsync(string directory, EnumMemoryStreamFile typeFile = EnumMemoryStreamFile.PDF);
    Task<bool> SendPushNotificationAsync(PushNotification notification, string tokenUser);
    string GenerateToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    void SaveRefreshToken(string username, string refreshToken);
    string GetRefreshToken(string username);
    void DeleteRefreshToken(string username, string refreshToken);
    string ExtractObjectInformationsByReflection(object obj);
    bool TokenIsValid(string jwtToken);
    void RefreshEnvironmentVarLocal(EnvironmentVarSettings environmentVarSettings);
    void RefreshEnvironmentVarAzure(EnvironmentVarSettings environmentVarSettings);
}
