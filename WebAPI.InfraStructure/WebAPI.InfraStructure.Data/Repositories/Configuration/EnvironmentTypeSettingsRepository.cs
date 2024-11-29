using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class EnvironmentTypeSettingsRepository : IEnvironmentTypeSettingsRepository
{
    private readonly IReadRepository<EnvironmentTypeSettings> _iEnvironmentTypeSettingsReadRepository;
    private readonly IWriteRepository<EnvironmentTypeSettings> _iEnvironmentTypeSettingsWriteRepository;

    public EnvironmentTypeSettingsRepository(
        IReadRepository<EnvironmentTypeSettings> iEnvironmentTypeSettingsReadRepository,
        IWriteRepository<EnvironmentTypeSettings> iEnvironmentTypeSettingsWriteRepository)
    {
        _iEnvironmentTypeSettingsReadRepository = iEnvironmentTypeSettingsReadRepository;
        _iEnvironmentTypeSettingsWriteRepository = iEnvironmentTypeSettingsWriteRepository;
    }

    public IQueryable<EnvironmentTypeSettings> GetAll(bool hasTracking = false)
    {
        return _iEnvironmentTypeSettingsReadRepository.GetAll(hasTracking);
    }

    public IQueryable<EnvironmentTypeSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iEnvironmentTypeSettingsReadRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<EnvironmentTypeSettings> FindBy(Expression<Func<EnvironmentTypeSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iEnvironmentTypeSettingsReadRepository.FindBy(predicate, hasTracking);
    }

    public EnvironmentTypeSettings GetById(long id)
    {
        return _iEnvironmentTypeSettingsReadRepository.GetById(id);
    }

    public bool Exist(Expression<Func<EnvironmentTypeSettings, bool>> predicate)
    {
        return _iEnvironmentTypeSettingsReadRepository.Exist(predicate);
    }

    public void Create(EnvironmentTypeSettings environmentTypeSettings)
    {
        _iEnvironmentTypeSettingsWriteRepository.Create(environmentTypeSettings);
    }

    public void Update(EnvironmentTypeSettings environmentTypeSettings)
    {
        _iEnvironmentTypeSettingsWriteRepository.Update(environmentTypeSettings);
    }
}
