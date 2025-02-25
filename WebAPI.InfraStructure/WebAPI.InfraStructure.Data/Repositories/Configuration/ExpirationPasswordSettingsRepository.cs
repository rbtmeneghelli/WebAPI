using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class ExpirationPasswordSettingsRepository : IExpirationPasswordSettingsRepository
{
    private readonly IReadRepository<ExpirationPasswordSettings> _iExpirationPasswordSettingsReadRepository;
    private readonly IWriteRepository<ExpirationPasswordSettings> _iExpirationPasswordSettingsWriteRepository;

    public ExpirationPasswordSettingsRepository(
        IReadRepository<ExpirationPasswordSettings> iExpirationPasswordSettingsReadRepository,
        IWriteRepository<ExpirationPasswordSettings> iExpirationPasswordSettingsWriteRepository)
    {
        _iExpirationPasswordSettingsReadRepository = iExpirationPasswordSettingsReadRepository;
        _iExpirationPasswordSettingsWriteRepository = iExpirationPasswordSettingsWriteRepository;
    }

    public IQueryable<ExpirationPasswordSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iExpirationPasswordSettingsReadRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<ExpirationPasswordSettings> FindBy(Expression<Func<ExpirationPasswordSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iExpirationPasswordSettingsReadRepository.GetByPredicate(predicate, hasTracking);
    }

    public ExpirationPasswordSettings GetById(long id)
    {
        return _iExpirationPasswordSettingsReadRepository.GetById(id);
    }

    public bool Exist(Expression<Func<ExpirationPasswordSettings, bool>> predicate)
    {
        return _iExpirationPasswordSettingsReadRepository.Exist(predicate);
    }

    public void Create(ExpirationPasswordSettings expirationPasswordSettings)
    {
        _iExpirationPasswordSettingsWriteRepository.Create(expirationPasswordSettings);
    }

    public void Update(ExpirationPasswordSettings expirationPasswordSettings)
    {
        _iExpirationPasswordSettingsWriteRepository.Update(expirationPasswordSettings);
    }
}
