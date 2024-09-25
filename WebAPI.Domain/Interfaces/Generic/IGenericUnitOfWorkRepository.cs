using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Application.InterfacesRepository;

public interface IGenericUnitofWorkRepository : IDisposable
{
    IAuditRepository AuditRepository { get; }
    IAddressRepository AddressRepository { get; }
    ICityRepository CityRepository { get; }
    IRegionRepository RegionRepository { get; }
    IStatesRepository StatesRepository { get; }
    IUserRepository UserRepository { get; }

    #region Configuration

    IAuthenticationSettingsRepository AuthenticationSettingsRepository { get; }
    IEmailDisplaySettingsRepository EmailDisplayRepository { get; }
    IEmailSettingsRepository EmailSettingsRepository { get; }
    IEnvironmentTypeSettingsRepository EnvironmentTypeSettingsRepository { get; }
    IExpirationPasswordSettingsRepository ExpirationPasswordSettingsRepository { get; }
    ILayoutSettingsRepository LayoutSettingsRepository { get; }
    ILogSettingsRepository LogSettingsRepository { get; }
    IRequiredPasswordSettingsRepository RequiredPasswordSettingsRepository { get; }

    #endregion
}
