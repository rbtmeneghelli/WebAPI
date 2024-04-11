namespace WebAPI.Application.Interfaces;

public interface IUnitofWorkRepository : IDisposable
{
    IAuditRepository Audits { get; }
    ICepRepository Ceps { get; }
    ICityRepository Cities { get; }
    IRegionRepository Regions { get; }
    IStatesRepository States { get; }
    IUserRepository Users { get; }
}
