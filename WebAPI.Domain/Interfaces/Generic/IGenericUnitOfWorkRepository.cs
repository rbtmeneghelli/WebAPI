namespace WebAPI.Application.InterfacesRepository;

public interface IGenericUnitofWorkRepository : IDisposable
{
    IAuditRepository Audits { get; }
    ICepRepository Ceps { get; }
    ICityRepository Cities { get; }
    IRegionRepository Regions { get; }
    IStatesRepository States { get; }
    IUserRepository Users { get; }
}
