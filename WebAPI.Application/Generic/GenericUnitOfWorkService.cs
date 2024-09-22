using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Generic;

public class GenericUnitOfWorkService : IGenericUnitOfWorkService
{
    public IAccountService iAccountService { get; }
    public IAuditService iAuditService { get; }
    public ICepService iCepService { get; }
    public ICityService iCityService { get; }
    public IRegionService iRegionService { get; }
    public IStatesService iStateService { get; }
    public IUserService iUserService { get; }

    public GenericUnitOfWorkService(
        IAccountService iAccountService,
        IAuditService iAuditService,
        ICepService iCepService,
        ICityService iCityService,
        IRegionService iRegionService,
        IStatesService iStateService,
        IUserService iUserService
        )
    {
        this.iAccountService = iAccountService ?? throw new ArgumentNullException(nameof(iAccountService));
        this.iAuditService = iAuditService ?? throw new ArgumentNullException(nameof(iAuditService));
        this.iCepService = iCepService ?? throw new ArgumentNullException(nameof(iCepService));
        this.iCityService = iCityService ?? throw new ArgumentNullException(nameof(iCityService));
        this.iRegionService = iRegionService ?? throw new ArgumentNullException(nameof(iRegionService));
        this.iStateService = iStateService ?? throw new ArgumentNullException(nameof(iStateService));
        this.iUserService = iUserService ?? throw new ArgumentNullException(nameof(iUserService));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

public class GenericNotifyLogsService : IGenericNotifyLogsService
{
    public INotificationMessageService iNotificationMessageService { get; }
    public IKissLogService iKissLogService { get; }

    public GenericNotifyLogsService(INotificationMessageService iNotificationMessageService, IKissLogService iKissLogService)
    {
        this.iNotificationMessageService = iNotificationMessageService ?? throw new ArgumentNullException(nameof(iNotificationMessageService));
        this.iKissLogService = iKissLogService ?? throw new ArgumentNullException(nameof(iKissLogService));
    }
}

public class GenericConfigurationService : IGenericConfigurationService
{
    public IEmailService iEmailService { get; }

    public IAuthenticationSettingsService iAuthenticationSettingsService { get; }

    public IEnvironmentTypeSettingsService iEnvironmentTypeSettingsService { get; }

    public IExpirationPasswordSettingsService iExpirationPasswordSettingsService { get; }

    public ILayoutSettingsService iLayoutSettingsService { get; }

    public ILogSettingsService iLogSettingsService { get; }

    public IRequiredPasswordSettingsService iRequiredPasswordSettingsService { get; }

    public GenericConfigurationService(
        IEmailService iEmailService,
        IAuthenticationSettingsService iAuthenticationSettingsService,
        IEnvironmentTypeSettingsService iEnvironmentTypeSettingsService,
        IExpirationPasswordSettingsService iExpirationPasswordSettingsService,
        ILayoutSettingsService iLayoutSettingsService,
        ILogSettingsService iLogSettingsService,
        IRequiredPasswordSettingsService iRequiredPasswordSettingsService
        )
    {
        this.iEmailService = iEmailService ?? throw new ArgumentNullException(nameof(iEmailService));
        this.iAuthenticationSettingsService = iAuthenticationSettingsService ?? throw new ArgumentNullException(nameof(iAuthenticationSettingsService));
        this.iEnvironmentTypeSettingsService = iEnvironmentTypeSettingsService ?? throw new ArgumentNullException(nameof(iEnvironmentTypeSettingsService));
        this.iExpirationPasswordSettingsService = iExpirationPasswordSettingsService ?? throw new ArgumentNullException(nameof(iExpirationPasswordSettingsService));
        this.iLayoutSettingsService = iLayoutSettingsService ?? throw new ArgumentNullException(nameof(iLayoutSettingsService));
        this.iLogSettingsService = iLogSettingsService ?? throw new ArgumentNullException(nameof(iLogSettingsService));
        this.iRequiredPasswordSettingsService = iRequiredPasswordSettingsService ?? throw new ArgumentNullException(nameof(iRequiredPasswordSettingsService));
    }
}