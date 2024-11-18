using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class ExpirationPasswordSettingsRepository : IExpirationPasswordSettingsRepository
{
    private readonly IGenericRepository<ExpirationPasswordSettings> _iExpirationPasswordSettingsRepository;

    public ExpirationPasswordSettingsRepository(IGenericRepository<ExpirationPasswordSettings> iExpirationPasswordSettingsRepository)
    {
        _iExpirationPasswordSettingsRepository = iExpirationPasswordSettingsRepository;
    }

    public IQueryable<ExpirationPasswordSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iExpirationPasswordSettingsRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<ExpirationPasswordSettings> FindBy(Expression<Func<ExpirationPasswordSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iExpirationPasswordSettingsRepository.FindBy(predicate, hasTracking);
    }

    public ExpirationPasswordSettings GetById(long id)
    {
        return _iExpirationPasswordSettingsRepository.GetById(id);
    }

    public bool Exist(Expression<Func<ExpirationPasswordSettings, bool>> predicate)
    {
        return _iExpirationPasswordSettingsRepository.Exist(predicate);
    }

    public void Create(ExpirationPasswordSettings expirationPasswordSettings)
    {
        _iExpirationPasswordSettingsRepository.Create(expirationPasswordSettings);
    }

    public void Update(ExpirationPasswordSettings expirationPasswordSettings)
    {
        _iExpirationPasswordSettingsRepository.Update(expirationPasswordSettings);
    }
}
