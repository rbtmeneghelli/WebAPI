using WebAPI.Application.InterfacesRepository;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Data.Repositories;

public class GenericUnitofWorkRepository : IGenericUnitofWorkRepository
{
    public IAuditRepository AuditRepository { get; }
    public IAddressRepository AddressRepository { get; }
    public ICityRepository CityRepository { get; }
    public IRegionRepository RegionRepository { get; }
    public IStatesRepository StatesRepository { get; } 
    public IUserRepository UserRepository { get; }
    public IAuthenticationSettingsRepository AuthenticationSettingsRepository { get; }
    public IEmailDisplayRepository EmailDisplayRepository { get; }
    public IEmailSettingsRepository EmailSettingsRepository { get; }
    public IEnvironmentTypeSettingsRepository EnvironmentTypeSettingsRepository { get; }
    public IExpirationPasswordSettingsRepository ExpirationPasswordSettingsRepository { get; }
    public ILayoutSettingsRepository LayoutSettingsRepository { get; }
    public ILogSettingsRepository LogSettingsRepository { get; }
    public IRequiredPasswordSettingsRepository RequiredPasswordSettingsRepository { get; }

    public GenericUnitofWorkRepository(
        IAuditRepository AuditRepository,
        IAddressRepository CepRepository,
        ICityRepository CityRepository,
        IRegionRepository RegionRepository,
        IStatesRepository StatesRepository,
        IUserRepository UserRepository,
        IAuthenticationSettingsRepository AuthenticationSettingsRepository,
        IEmailDisplayRepository EmailDisplayRepository,
        IEmailSettingsRepository EmailSettingsRepository,
        IEnvironmentTypeSettingsRepository EnvironmentTypeSettingsRepository,
        IExpirationPasswordSettingsRepository ExpirationPasswordSettingsRepository,
        ILayoutSettingsRepository LayoutSettingsRepository,
        ILogSettingsRepository LogSettingsRepository,
        IRequiredPasswordSettingsRepository RequiredPasswordSettingsRepository
        )
    {
        this.AuditRepository = AuditRepository ?? throw new ArgumentNullException(nameof(AuditRepository));
        this.AddressRepository = AddressRepository ?? throw new ArgumentNullException(nameof(AddressRepository));
        this.CityRepository = CityRepository ?? throw new ArgumentNullException(nameof(CityRepository));
        this.RegionRepository = RegionRepository ?? throw new ArgumentNullException(nameof(RegionRepository));
        this.StatesRepository = StatesRepository ?? throw new ArgumentNullException(nameof(StatesRepository));
        this.UserRepository = UserRepository ?? throw new ArgumentNullException(nameof(UserRepository));

        this.AuthenticationSettingsRepository = AuthenticationSettingsRepository ?? throw new ArgumentNullException(nameof(AuthenticationSettingsRepository));
        this.EmailDisplayRepository = EmailDisplayRepository ?? throw new ArgumentNullException(nameof(EmailDisplayRepository));
        this.EmailSettingsRepository = EmailSettingsRepository ?? throw new ArgumentNullException(nameof(EmailSettingsRepository));
        this.EnvironmentTypeSettingsRepository = EnvironmentTypeSettingsRepository ?? throw new ArgumentNullException(nameof(EnvironmentTypeSettingsRepository));
        this.ExpirationPasswordSettingsRepository = ExpirationPasswordSettingsRepository ?? throw new ArgumentNullException(nameof(ExpirationPasswordSettingsRepository));
        this.LayoutSettingsRepository = LayoutSettingsRepository ?? throw new ArgumentNullException(nameof(LayoutSettingsRepository));
        this.LogSettingsRepository = LogSettingsRepository ?? throw new ArgumentNullException(nameof(LogSettingsRepository));
        this.RequiredPasswordSettingsRepository = RequiredPasswordSettingsRepository ?? throw new ArgumentNullException(nameof(RequiredPasswordSettingsRepository));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
