using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Application.InterfacesRepository;

public interface IGenericUnitofWorkRepository : IDisposable
{
    IAuditRepository Audits { get; }
    ICepRepository Ceps { get; }
    ICityRepository Cities { get; }
    IRegionRepository Regions { get; }
    IStatesRepository States { get; }
    IUserRepository Users { get; }

    #region Configuration

    IAuthenticationSettingsRepository AuthenticationSettings { get; }
    IEmailDisplayRepository EmailDisplay { get; }
    IEmailSettingsRepository EmailSettings { get; }
    IEnvironmentTypeSettingsRepository EnvironmentTypeSettings { get; }
    IExpirationPasswordSettingsRepository ExpirationPasswordSettings { get; }
    ILayoutSettingsRepository LayoutSettings { get; }
    ILogSettingsRepository LogSettings { get; }
    IRequiredPasswordSettingsRepository RequiredPasswordSettings { get; }

    #endregion
}
