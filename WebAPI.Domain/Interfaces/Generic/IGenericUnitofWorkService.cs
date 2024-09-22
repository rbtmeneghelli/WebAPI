using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Domain.Interfaces.Repository;

public interface IGenericUnitOfWorkService : IDisposable
{
    IAccountService AccountService { get; }
    IAuditService AuditService { get; }
    IAddressService AddressService { get; }
    ICityService CityService { get; }
    IRegionService RegionService { get; }
    IStatesService StateService { get; }
    IUserService UserService { get; }
}

public interface IGenericNotifyLogsService
{
    INotificationMessageService NotificationMessageService { get; }
    IGeneralLogService GeneralLogService { get; }
}

public interface IGenericConfigurationService
{
    IEmailService EmailService { get; }
    IAuthenticationSettingsService AuthenticationSettingsService { get; }
    IEnvironmentTypeSettingsService EnvironmentTypeSettingsService { get; }
    IExpirationPasswordSettingsService ExpirationPasswordSettingsService { get; }
    ILayoutSettingsService LayoutSettingsService { get; }
    ILogSettingsService LogSettingsService { get; }
    IRequiredPasswordSettingsService RequiredPasswordSettingsService { get; }
}