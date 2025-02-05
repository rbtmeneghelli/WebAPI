using WebAPI.Domain.Cryptography;
using WebAPI.Domain.ExtensionMethods;
using Microsoft.Extensions.Hosting;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Application.Services;

public class AccountService : GenericService, IAccountService
{
    private readonly IUserRepository _iUserRepository;
    private readonly IEmailService _iEmailService;
    private readonly IHostEnvironment _hostingEnvironment;

    public AccountService(IUserRepository iUserRepository, IEmailService iEmailService, INotificationMessageService iNotificationMessageService, IHostEnvironment hostingEnvironment) : base(iNotificationMessageService)
    {
        _iUserRepository = iUserRepository;
        _iEmailService = iEmailService;
        _hostingEnvironment = hostingEnvironment;
    }

    public async Task<bool> CheckUserAuthenticationAsync(LoginUser loginUser)
    {
        try
        {

            User user = await _iUserRepository.FindBy(x => x.Login == loginUser.Login.ApplyTrim() && x.Status == true).FirstOrDefaultAsync();
            if (GuardClauses.ObjectIsNotNull(user))
            {
                if (HashingManager.GetLoadHashingManager().Verify(loginUser.Password, user.Password))
                    return true;

                Notify("Autenticação invalida. Tente novamente!");
            }
            else
            {
                Notify("Autenticação invalida. Tente novamente!");
            }

            return false;
        }
        catch
        {
            Notify("Erro na validação");
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<Credentials> GetUserCredentialsAsync(string login)
    {
        try
        {
            Credentials credentials = new Credentials();
            User user = await _iUserRepository.GetUserCredentialsByLogin(login);

            if (GuardClauses.ObjectIsNotNull(user))
            {
                credentials.Id = user.Id;
                credentials.Login = user.Login;
                credentials.Perfil = user.Employee.Profile.Description;
                credentials.Roles = Enumerable.Empty<string>().ToList();
                credentials.AccessDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
                credentials.CodeTwoFactoryCode = user.HasTwoFactoryValidation
                                                 ? GenerateCodeTwoFactory(user.Id.Value, user.Login)
                                                 : StringExtensionMethod.GetEmptyString();

                IEnumerable<string> userRoles = user.Employee.Profile.ProfileOperations.Where(x => x.IsEnable).Select(x => x.RoleTag);
                credentials.Roles.AddRange(userRoles);
            }

            return credentials;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_LOGIN);
            return default;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> ChangePasswordAsync(long id, User user)
    {
        try
        {
            User dbUser = _iUserRepository.GetById(id);
            if (GuardClauses.ObjectIsNotNull(dbUser))
            {
                if (HashingManager.GetLoadHashingManager().Verify(user.Password, dbUser.Password) && dbUser.Login == user.Login.ApplyTrim())
                {
                    dbUser.LastPassword = dbUser.Password;
                    dbUser.Password = HashingManager.GetLoadHashingManager().HashToString(user.Password);
                    dbUser.IsAuthenticated = true;
                    dbUser.UpdateDate = dbUser.GetNewUpdateDate();
                    _iUserRepository.Update(dbUser);
                    await Task.CompletedTask;
                    return true;
                }
            }

            Notify(FixConstants.ERROR_IN_CHANGEPASSWORD);
            return false;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_CHANGEPASSWORD);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> ResetPasswordAsync(string login)
    {
        try
        {
            if (GuardClauses.IsNullOrWhiteSpace(login) == false)
            {
                User user = await _iUserRepository.FindBy(x => x.Login == login.ApplyTrim()).FirstOrDefaultAsync();
                if (GuardClauses.ObjectIsNotNull(user))
                {
                    user.LastPassword = user.Password;
                    user.Password = HashingManager.GetLoadHashingManager().HashToString(FixConstants.DEFAULT_PASSWORD);
                    user.IsAuthenticated = false;
                    user.Status = true;
                    user.UpdateDate = user.GetNewUpdateDate();
                    _iEmailService.CustomSendEmailAsync(EnumEmail.ResetPassword, "Dev", _hostingEnvironment.ContentRootPath).Wait();
                    _iUserRepository.Update(user);
                    return true;
                }

                Notify(FixConstants.ERROR_IN_RESETPASSWORD);
            }
            Notify(FixConstants.ERROR_IN_RESETPASSWORD);
            return false;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_RESETPASSWORD);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<Credentials> GetUserCredentialsByIdAsync(long id)
    {
        try
        {
            Credentials credentials = new Credentials();
            User user = await _iUserRepository.GetUserCredentialsById(id);

            if (GuardClauses.ObjectIsNotNull(user))
            {
                credentials.Id = user.Id;
                credentials.Login = user.Login;
                credentials.Perfil = user.Employee.Profile.Description;
                credentials.Roles = Enumerable.Empty<string>().ToList();
                IEnumerable<string> userRoles = user.Employee.Profile.ProfileOperations.Where(x => x.IsEnable).Select(x => x.RoleTag);
                credentials.Roles.AddRange(userRoles);
            }

            return credentials;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_LOGIN);
            return default;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    #region Metodos para validação de acesso em duas etapas

    public string GenerateCodeTwoFactory(long userId, string username)
    {
        byte[] dataBytes = Encoding.UTF8.GetBytes($"{userId}//{username}:{DateTime.Now.Ticks}");
        using SHA256 sha256 = SHA256.Create();
        byte[] hashBytes = sha256.ComputeHash(dataBytes);
        string codeTwoFactory = Convert.ToBase64String(hashBytes);
        return codeTwoFactory;
    }

    public bool CheckCodeTwoFactory(long userId, string username, string inputCodeTwoFactory)
    {
        long expirationTime = TimeSpan.FromMinutes(10).Ticks;
        long ticksNow = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil().Ticks;
        string expectedCode = GenerateCodeTwoFactory(userId, username);
        bool codesMatch = (inputCodeTwoFactory == expectedCode);
        bool withinExpiration = (DateOnlyExtensionMethods.GetDateTimeNowFromBrazil().Ticks - ticksNow) <= expirationTime;
        return codesMatch && withinExpiration; // Se for true o codigo da validação de duas etapas está OK
    }

    #endregion
}

