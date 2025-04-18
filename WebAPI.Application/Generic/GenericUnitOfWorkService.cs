using FastPackForShare.Interfaces;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Generic;

public class GenericUnitOfWorkService : IGenericUnitOfWorkService
{
    public IAccountService AccountService { get; }
    public IAuditService AuditService { get; }
    public IAddressService AddressService { get; }
    public ICityService CityService { get; }
    public IRegionService RegionService { get; }
    public IStatesService StateService { get; }
    public IUserService UserService { get; }

    public GenericUnitOfWorkService(
        IAccountService AccountService,
        IAuditService AuditService,
        IAddressService AddressService,
        ICityService CityService,
        IRegionService RegionService,
        IStatesService StateService,
        IUserService UserService
        )
    {
        this.AccountService = AccountService ?? throw new ArgumentNullException(nameof(AccountService));
        this.AuditService = AuditService ?? throw new ArgumentNullException(nameof(AuditService));
        this.AddressService = AddressService ?? throw new ArgumentNullException(nameof(AddressService));
        this.CityService = CityService ?? throw new ArgumentNullException(nameof(CityService));
        this.RegionService = RegionService ?? throw new ArgumentNullException(nameof(RegionService));
        this.StateService = StateService ?? throw new ArgumentNullException(nameof(StateService));
        this.UserService = UserService ?? throw new ArgumentNullException(nameof(UserService));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

public class GenericNotifyLogsService : IGenericNotifyLogsService
{
    public INotificationMessageService NotificationMessageService { get; }
    public IGeneralLogService GeneralLogService { get; }

    public GenericNotifyLogsService(INotificationMessageService NotificationMessageService, IGeneralLogService GeneralLogService)
    {
        this.NotificationMessageService = NotificationMessageService ?? throw new ArgumentNullException(nameof(NotificationMessageService));
        this.GeneralLogService = GeneralLogService ?? throw new ArgumentNullException(nameof(GeneralLogService));
    }
}

public class GenericConfigurationService : IGenericConfigurationService
{
    public IEmailService EmailService { get; }

    public IAuthenticationSettingsService AuthenticationSettingsService { get; }

    public IEnvironmentTypeSettingsService EnvironmentTypeSettingsService { get; }

    public IExpirationPasswordSettingsService ExpirationPasswordSettingsService { get; }

    public ILayoutSettingsService LayoutSettingsService { get; }

    public ILogSettingsService LogSettingsService { get; }

    public IRequiredPasswordSettingsService RequiredPasswordSettingsService { get; }

    public IEmailDisplaySettingsService EmailDisplaySettingsService { get; }

    public IEmailSettingsService EmailSettingsService { get; }

    public IUploadSettingsService UploadSettingsService { get; }

    public GenericConfigurationService(
        IEmailService EmailService,
        IAuthenticationSettingsService AuthenticationSettingsService,
        IEnvironmentTypeSettingsService EnvironmentTypeSettingsService,
        IExpirationPasswordSettingsService ExpirationPasswordSettingsService,
        ILayoutSettingsService LayoutSettingsService,
        ILogSettingsService LogSettingsService,
        IRequiredPasswordSettingsService RequiredPasswordSettingsService,
        IEmailDisplaySettingsService EmailDisplaySettingsService,
        IEmailSettingsService EmailSettingsService,
        IUploadSettingsService UploadSettingsService
        )
    {
        this.EmailService = EmailService ?? throw new ArgumentNullException(nameof(EmailService));
        this.AuthenticationSettingsService = AuthenticationSettingsService ?? throw new ArgumentNullException(nameof(AuthenticationSettingsService));
        this.EnvironmentTypeSettingsService = EnvironmentTypeSettingsService ?? throw new ArgumentNullException(nameof(EnvironmentTypeSettingsService));
        this.ExpirationPasswordSettingsService = ExpirationPasswordSettingsService ?? throw new ArgumentNullException(nameof(ExpirationPasswordSettingsService));
        this.LayoutSettingsService = LayoutSettingsService ?? throw new ArgumentNullException(nameof(LayoutSettingsService));
        this.LogSettingsService = LogSettingsService ?? throw new ArgumentNullException(nameof(LogSettingsService));
        this.RequiredPasswordSettingsService = RequiredPasswordSettingsService ?? throw new ArgumentNullException(nameof(RequiredPasswordSettingsService));
        this.EmailDisplaySettingsService = EmailDisplaySettingsService ?? throw new ArgumentNullException(nameof(EmailDisplaySettingsService));
        this.EmailSettingsService = EmailSettingsService ?? throw new ArgumentNullException(nameof(EmailSettingsService));
        this.UploadSettingsService = UploadSettingsService ?? throw new ArgumentNullException(nameof(UploadSettingsService));
    }
}