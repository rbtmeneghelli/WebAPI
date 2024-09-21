using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Domain.Interfaces.Repository;

public interface IGenericUnitofWorkService : IDisposable
{
    IAccountService Accounts { get; }
    IAuditService Audits { get; }
    ICepService Ceps { get; }
    ICityService Cities { get; }
    IRegionService Regions { get; }
    IStatesService States { get; }
    IUserService Users { get; }

    #region Configuration
    IEmailService EmailService { get; }
    IAuthenticationSettingsService AuthenticationSettings { get; }
    IEnvironmentTypeSettingsService EnvironmentTypeSettings { get; }
    IExpirationPasswordSettingsService ExpirationPasswordSettings { get; }
    ILayoutSettingsService LayoutSettings { get; }
    ILogSettingsService LogSettings { get; }
    IRequiredPasswordSettingsService RequiredPasswordSettings { get; }

    #endregion
}

public interface IGenericNotifyLogsService
{
    INotificationMessageService iNotificationMessageService { get; }
    IKissLogService iKissLogService { get; }
}

