using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class EnvironmentTypeSettingsRepository : IEnvironmentTypeSettingsRepository
{
    private readonly IGenericRepository<EnvironmentTypeSettings> _iEnvironmentTypeSettingsRepository;

    public EnvironmentTypeSettingsRepository(IGenericRepository<EnvironmentTypeSettings> iEnvironmentTypeSettingsRepository)
    {
        _iEnvironmentTypeSettingsRepository = iEnvironmentTypeSettingsRepository;
    }

    public IQueryable<EnvironmentTypeSettings> GetAll(bool hasTracking = false)
    {
        return _iEnvironmentTypeSettingsRepository.GetAll(hasTracking);
    }

    public IQueryable<EnvironmentTypeSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iEnvironmentTypeSettingsRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<EnvironmentTypeSettings> FindBy(Expression<Func<EnvironmentTypeSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iEnvironmentTypeSettingsRepository.FindBy(predicate, hasTracking);
    }

    public EnvironmentTypeSettings GetById(long id)
    {
        return _iEnvironmentTypeSettingsRepository.GetById(id);
    }

    public bool Exist(Expression<Func<EnvironmentTypeSettings, bool>> predicate)
    {
        return _iEnvironmentTypeSettingsRepository.Exist(predicate);
    }

    public void Create(EnvironmentTypeSettings environmentTypeSettings)
    {
        _iEnvironmentTypeSettingsRepository.Create(environmentTypeSettings);
    }

    public void Update(EnvironmentTypeSettings environmentTypeSettings)
    {
        _iEnvironmentTypeSettingsRepository.Update(environmentTypeSettings);
    }
}
