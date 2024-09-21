using WebAPI.Application.Interfaces;

namespace WebAPI.Domain.Interfaces.Repository;

public interface IGenericUnitofWorkService : IDisposable
{
    IAccountService Accounts { get; }
    IAuditService Audits { get; }
    ICepService Ceps { get; }
    ICityService Cities { get; }
    IRegionService Regions { get; }
    IStatesService States { get; }
    IUserService Users { get; }
}

