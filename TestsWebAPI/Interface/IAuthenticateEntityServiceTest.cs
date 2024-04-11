namespace TestsWebAPI.Interface;

public interface IAuthenticateEntityServiceTest : IDisposable
{
    bool ExistAuthentication();
    void InsertDefaultAuthenticate();
    bool IsValidAuthentication(AuthenticateEntity authenticateEntity);
    AuthenticateEntity GetAuthenticate(long authId = 1L);
    void InsertAuthenticate(AuthenticateEntity authenticateEntity);
    void UpdateAuthenticate(AuthenticateEntity authenticateEntity);
}
