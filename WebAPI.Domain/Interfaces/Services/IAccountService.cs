using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface IAccountService
{
    Task<bool> CheckUserAuthenticationAsync(LoginUser loginUser);
    Task<Credentials> GetUserCredentialsAsync(string login);
    Task<bool> ChangePasswordAsync(long id, User user);
    Task<bool> ResetPasswordAsync(string email);
    Task<Credentials> GetUserCredentialsByIdAsync(long id);

    #region Metodos para validação de acesso em duas etapas
    string GenerateCodeTwoFactory(long userId, string username);
    bool CheckCodeTwoFactory(long userId, string username, string inputCodeTwoFactory);
    #endregion
}
