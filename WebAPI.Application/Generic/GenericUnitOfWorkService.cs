using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Generic;

public class GenericUnitOfWorkService : IGenericUnitofWorkService
{
    public IAccountService Accounts { get; }
    public IAuditService Audits { get; }
    public ICepService Ceps { get; }
    public ICityService Cities { get; }
    public IRegionService Regions { get; }
    public IStatesService States { get; }
    public IUserService Users { get; }

    public IEmailService EmailService { get; }

    public IAuthenticationSettingsService AuthenticationSettings { get; }

    public IEnvironmentTypeSettingsService EnvironmentTypeSettings { get; }

    public IExpirationPasswordSettingsService ExpirationPasswordSettings { get; }

    public ILayoutSettingsService LayoutSettings { get; }

    public ILogSettingsService LogSettings { get; }

    public IRequiredPasswordSettingsService RequiredPasswordSettings { get; }

    public GenericUnitOfWorkService(
        IAccountService Accounts,
        IAuditService Audits,
        ICepService Ceps,
        ICityService Cities,
        IRegionService Regions,
        IStatesService States,
        IUserService Users
        )
    {
        this.Accounts = Accounts ?? throw new ArgumentNullException(nameof(Accounts));
        this.Audits = Audits ?? throw new ArgumentNullException(nameof(Audits));
        this.Ceps = Ceps ?? throw new ArgumentNullException(nameof(Ceps));
        this.Cities = Cities ?? throw new ArgumentNullException(nameof(Cities));
        this.Regions = Regions ?? throw new ArgumentNullException(nameof(Regions));
        this.States = States ?? throw new ArgumentNullException(nameof(States));
        this.Users = Users ?? throw new ArgumentNullException(nameof(Users));

        this.EmailService = EmailService ?? throw new ArgumentNullException(nameof(EmailService));
        this.AuthenticationSettings = AuthenticationSettings ?? throw new ArgumentNullException(nameof(AuthenticationSettings));
        this.EnvironmentTypeSettings = EnvironmentTypeSettings ?? throw new ArgumentNullException(nameof(EnvironmentTypeSettings));
        this.ExpirationPasswordSettings = ExpirationPasswordSettings ?? throw new ArgumentNullException(nameof(ExpirationPasswordSettings));
        this.LayoutSettings = LayoutSettings ?? throw new ArgumentNullException(nameof(LayoutSettings));
        this.LogSettings = LogSettings ?? throw new ArgumentNullException(nameof(LogSettings));
        this.RequiredPasswordSettings = RequiredPasswordSettings ?? throw new ArgumentNullException(nameof(RequiredPasswordSettings));
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