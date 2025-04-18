using Microsoft.Extensions.Hosting;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Application.Services;

public sealed class AccountService : BaseHandlerService, IAccountService
{
    private readonly IUserRepository _iUserRepository;
    private readonly IEmailService _iEmailService;
    private readonly IHostEnvironment _hostingEnvironment;

    public AccountService(
        IUserRepository iUserRepository, 
        IEmailService iEmailService, 
        INotificationMessageService iNotificationMessageService, 
        IHostEnvironment hostingEnvironment) : base(iNotificationMessageService)
    {
        _iUserRepository = iUserRepository;
        _iEmailService = iEmailService;
        _hostingEnvironment = hostingEnvironment;
    }

    public async Task<bool> CheckUserAuthenticationAsync(LoginUser loginUser)
    {
        User user = await _iUserRepository.FindBy(x => x.Login == loginUser.Login.ApplyTrim() && x.IsActive == true).FirstOrDefaultAsync();

        if (GuardClauseExtension.IsNotNull(user))
        {
            if (new HashingManager().Verify(loginUser.Password, user.Password))
                return true;

            Notify("Autenticação invalida. Tente novamente!");
        }
        else
        {
            Notify("Autenticação invalida. Tente novamente!");
        }

        return false;
    }

    public async Task<AuthenticationModel> GetUserAuthenticationAsync(string login)
    {
        AuthenticationModel authenticationModel = new AuthenticationModel();
        User user = await _iUserRepository.GetUserCredentialsByLogin(login);

        if (GuardClauseExtension.IsNotNull(user))
        {
            authenticationModel.Id = user.Id;
            authenticationModel.Login = user.Login;
            authenticationModel.Profile = user.Employee.Profile.Description;
            authenticationModel.Roles = Enumerable.Empty<Claim>().ToList();
            authenticationModel.AccessDate = DateOnlyExtension.GetDateTimeNowFromBrazil();
            authenticationModel.CodeTwoFactoryCode = user.HasTwoFactoryValidation
                                             ? GenerateCodeTwoFactory(user.Id.Value, user.Login)
                                             : string.Empty;

            IEnumerable<string> userRoles = user.Employee.Profile.ProfileOperations.Where(x => x.IsEnable).Select(x => x.RoleTag);
            authenticationModel.Roles.Add(new Claim(ClaimTypes.Role, string.Join(",", userRoles)));
        }

        return authenticationModel;
    }

    public async Task<bool> ChangePasswordAsync(long id, User user)
    {
        User dbUser = _iUserRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(dbUser))
        {
            if (new HashingManager().Verify(user.Password, dbUser.Password) && dbUser.Login == user.Login.ApplyTrim())
            {
                dbUser.LastPassword = dbUser.Password;
                dbUser.Password = new HashingManager().HashToString(user.Password);
                dbUser.IsAuthenticated = true;
                dbUser.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
                _iUserRepository.Update(dbUser);
                await Task.CompletedTask;
                return true;
            }
        }

        Notify(FixConstants.ERROR_IN_CHANGEPASSWORD);
        return false;
    }

    public async Task<bool> ResetPasswordAsync(string login)
    {
        if (GuardClauseExtension.IsNullOrWhiteSpace(login) == false)
        {
            User user = await _iUserRepository.FindBy(x => x.Login == login.ApplyTrim()).FirstOrDefaultAsync();

            if (GuardClauseExtension.IsNotNull(user))
            {
                user.LastPassword = user.Password;
                user.Password = new HashingManager().HashToString(FixConstants.DEFAULT_PASSWORD);
                user.IsAuthenticated = false;
                user.IsActive = true;
                user.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
                _iEmailService.CustomSendEmailAsync(EnumEmail.ResetPassword, "Dev", _hostingEnvironment.ContentRootPath).Wait();
                _iUserRepository.Update(user);
                return true;
            }

            Notify(FixConstants.ERROR_IN_RESETPASSWORD);
        }

        Notify(FixConstants.ERROR_IN_RESETPASSWORD);
        return false;
    }

    public async Task<AuthenticationModel> GetUserAuthenticationByIdAsync(long id)
    {
        AuthenticationModel authenticationModel = new AuthenticationModel();
        User user = await _iUserRepository.GetUserCredentialsById(id);

        if (GuardClauseExtension.IsNotNull(user))
        {
            authenticationModel.Id = user.Id;
            authenticationModel.Login = user.Login;
            authenticationModel.Profile = user.Employee.Profile.Description;
            authenticationModel.Roles = Enumerable.Empty<Claim>().ToList();
            IEnumerable<string> userRoles = user.Employee.Profile.ProfileOperations.Where(x => x.IsEnable).Select(x => x.RoleTag);
            authenticationModel.Roles.Add(new Claim(ClaimTypes.Role, string.Join(",", userRoles)));
        }

        return authenticationModel;
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
        long ticksNow = DateOnlyExtension.GetDateTimeNowFromBrazil().Ticks;
        string expectedCode = GenerateCodeTwoFactory(userId, username);
        bool codesMatch = (inputCodeTwoFactory == expectedCode);
        bool withinExpiration = (DateOnlyExtension.GetDateTimeNowFromBrazil().Ticks - ticksNow) <= expirationTime;
        return codesMatch && withinExpiration; // Se for true o codigo da validação de duas etapas está OK
    }

    #endregion
}

