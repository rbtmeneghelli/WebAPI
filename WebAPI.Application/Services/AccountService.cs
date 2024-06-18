using WebAPI.Domain.Cryptography;
using WebAPI.Domain.ExtensionMethods;
using Microsoft.Extensions.Hosting;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;

namespace WebAPI.Application.Services;

public class AccountService : GenericService, IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;
    private readonly IHostEnvironment _hostingEnvironment;

    public AccountService(IUserRepository userRepository, IEmailService emailService, INotificationMessageService notificationMessageService, IHostEnvironment hostingEnvironment) : base(notificationMessageService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
        _hostingEnvironment = hostingEnvironment;
    }

    private IEnumerable<EnumActions> GetActions(ProfileOperation profileOperation)
    {
        IEnumerable<EnumActions> condition = new List<EnumActions>
        {
            profileOperation.CanCreate ? EnumActions.Insert : EnumActions.None,
            profileOperation.CanResearch ? EnumActions.Research : EnumActions.None,
            profileOperation.CanUpdate ? EnumActions.Update : EnumActions.None,
            profileOperation.CanDelete ? EnumActions.Delete : EnumActions.None,
            profileOperation.CanExport ? EnumActions.Export : EnumActions.None,
            profileOperation.CanImport ? EnumActions.Import : EnumActions.None
        };
        return condition;
    }

    public async Task<bool> CheckUserAuthenticationAsync(LoginUser loginUser)
    {
        try
        {

            User user = await _userRepository.FindBy(x => x.Login == loginUser.Login.ApplyTrim() && x.IsActive == true).FirstOrDefaultAsync();
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
            User user = await _userRepository.GetUserCredentialsByLogin(login);

            if (GuardClauses.ObjectIsNotNull(user))
            {
                credentials.Id = user.Id;
                credentials.Login = user.Login;
                credentials.Perfil = user.Profile.Description;
                credentials.Roles = Enumerable.Empty<string>().ToList();
                credentials.AccessDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
                foreach (var item in user.Profile.ProfileOperations)
                {
                    IEnumerable<EnumActions> condition = GetActions(item);
                    credentials.Roles.AddRange(item.Operation.Roles.Where(y => condition.Contains(y.Action)).Select(z => z.RoleTag).ToList());
                }
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
            User dbUser = _userRepository.GetById(id);
            if (GuardClauses.ObjectIsNotNull(dbUser))
            {
                if (HashingManager.GetLoadHashingManager().Verify(user.Password, dbUser.Password) && dbUser.Login == user.Login.ApplyTrim())
                {
                    dbUser.LastPassword = dbUser.Password;
                    dbUser.Password = HashingManager.GetLoadHashingManager().HashToString(user.Password);
                    dbUser.IsAuthenticated = true;
                    dbUser.UpdateTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
                    _userRepository.Update(dbUser);
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
                User user = await _userRepository.FindBy(x => x.Login == login.ApplyTrim()).FirstOrDefaultAsync();
                if (GuardClauses.ObjectIsNotNull(user))
                {
                    user.LastPassword = user.Password;
                    user.Password = HashingManager.GetLoadHashingManager().HashToString(FixConstants.DEFAULT_PASSWORD);
                    user.IsAuthenticated = false;
                    user.IsActive = true;
                    user.CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
                    _emailService.SendEmailToResetPswAsync("Roberto", _hostingEnvironment.ContentRootPath).Wait();
                    _userRepository.Update(user);
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
            Credentials credenciais = new Credentials();
            User user = await _userRepository.GetUserCredentialsById(id);

            if (GuardClauses.ObjectIsNotNull(user))
            {
                credenciais.Id = user.Id;
                credenciais.Login = user.Login;
                credenciais.Perfil = user.Profile.Description;
                credenciais.Roles = Enumerable.Empty<string>().ToList();
                foreach (var item in user.Profile.ProfileOperations)
                {
                    IEnumerable<EnumActions> condition = GetActions(item);
                    credenciais.Roles.AddRange(item.Operation.Roles.Where(y => condition.Contains(y.Action)).Select(z => z.RoleTag).ToList());
                }
            }

            return credenciais;
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
}

