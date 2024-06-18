namespace WebAPI.Application.Generic;

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

