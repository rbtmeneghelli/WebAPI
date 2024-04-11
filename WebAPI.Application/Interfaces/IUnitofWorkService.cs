namespace WebAPI.Application.Interfaces;

public interface IUnitofWorkService : IDisposable
{
    IAccountService Accounts { get; }
    IAuditService Audits { get; }
    ICepService Ceps { get; }
    ICityService Cities { get; }
    IRegionService Regions { get; }
    IStatesService States { get; }
    IUserService Users { get; }
}

