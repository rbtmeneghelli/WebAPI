using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Domain.Interfaces.Repository;

public interface IGenericUnitOfWorkService : IDisposable
{
    IAccountService iAccountService { get; }
    IAuditService iAuditService { get; }
    ICepService iCepService { get; }
    ICityService iCityService { get; }
    IRegionService iRegionService { get; }
    IStatesService iStateService { get; }
    IUserService iUserService { get; }
}

public interface IGenericNotifyLogsService
{
    INotificationMessageService iNotificationMessageService { get; }
    IKissLogService iKissLogService { get; }
}

public interface IGenericConfigurationService
{
    IEmailService iEmailService { get; }
    IAuthenticationSettingsService iAuthenticationSettingsService { get; }
    IEnvironmentTypeSettingsService iEnvironmentTypeSettingsService { get; }
    IExpirationPasswordSettingsService iExpirationPasswordSettingsService { get; }
    ILayoutSettingsService iLayoutSettingsService { get; }
    ILogSettingsService iLogSettingsService { get; }
    IRequiredPasswordSettingsService iRequiredPasswordSettingsService { get; }
}