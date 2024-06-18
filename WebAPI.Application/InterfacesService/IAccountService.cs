namespace WebAPI.Application.Interfaces;

public interface IAccountService
{
    Task<bool> CheckUserAuthenticationAsync(LoginUser loginUser);
    Task<Credentials> GetUserCredentialsAsync(string login);
    Task<bool> ChangePasswordAsync(long id, User user);
    Task<bool> ResetPasswordAsync(string email);
    Task<Credentials> GetUserCredentialsByIdAsync(long id);
}
