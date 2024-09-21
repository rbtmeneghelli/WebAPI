using WebAPI.Application.InterfacesRepository;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Data.Repositories;

public class UnitOfWorkRepository : IGenericUnitofWorkRepository
{
    public IAuditRepository Audits { get; }
    public ICepRepository Ceps { get; }
    public ICityRepository Cities { get; }
    public IRegionRepository Regions { get; }
    public IStatesRepository States { get; } 
    public IUserRepository Users { get; }

    public IAuthenticationSettingsRepository AuthenticationSettings { get; }

    public IEmailDisplayRepository EmailDisplay { get; }

    public IEmailSettingsRepository EmailSettings { get; }

    public IEnvironmentTypeSettingsRepository EnvironmentTypeSettings { get; }

    public IExpirationPasswordSettingsRepository ExpirationPasswordSettings { get; }

    public ILayoutSettingsRepository LayoutSettings { get; }

    public ILogSettingsRepository LogSettings { get; }

    public IRequiredPasswordSettingsRepository RequiredPasswordSettings { get; }

    public UnitOfWorkRepository(
        IAuditRepository Audits,
        ICepRepository Ceps,
        ICityRepository Cities,
        IRegionRepository Regions,
        IStatesRepository States,
        IUserRepository Users,
        IAuthenticationSettingsRepository authenticationSettings,
        IEmailDisplayRepository emailDisplay,
        IEmailSettingsRepository emailSettings,
        IEnvironmentTypeSettingsRepository environmentTypeSettings,
        IExpirationPasswordSettingsRepository expirationPasswordSettings,
        ILayoutSettingsRepository layoutSettings,
        ILogSettingsRepository logSettings,
        IRequiredPasswordSettingsRepository requiredPasswordSettings
        )
    {
        this.Audits = Audits ?? throw new ArgumentNullException(nameof(Audits));
        this.Ceps = Ceps ?? throw new ArgumentNullException(nameof(Ceps));
        this.Cities = Cities ?? throw new ArgumentNullException(nameof(Cities));
        this.Regions = Regions ?? throw new ArgumentNullException(nameof(Regions));
        this.States = States ?? throw new ArgumentNullException(nameof(States));
        this.Users = Users ?? throw new ArgumentNullException(nameof(Users));

        this.AuthenticationSettings = authenticationSettings ?? throw new ArgumentNullException(nameof(authenticationSettings));
        this.EmailDisplay = emailDisplay ?? throw new ArgumentNullException(nameof(emailDisplay));
        this.EmailSettings = emailSettings ?? throw new ArgumentNullException(nameof(emailSettings));
        this.EnvironmentTypeSettings = environmentTypeSettings ?? throw new ArgumentNullException(nameof(environmentTypeSettings));
        this.ExpirationPasswordSettings = expirationPasswordSettings ?? throw new ArgumentNullException(nameof(expirationPasswordSettings));
        this.LayoutSettings = layoutSettings ?? throw new ArgumentNullException(nameof(layoutSettings));
        this.LogSettings = logSettings ?? throw new ArgumentNullException(nameof(logSettings));
        this.RequiredPasswordSettings = requiredPasswordSettings ?? throw new ArgumentNullException(nameof(requiredPasswordSettings));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
