using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class LogSettingsRepository : ILogSettingsRepository
{
    private readonly IGenericRepository<LogSettings> _iLogSettingsRepository;

    public LogSettingsRepository(IGenericRepository<LogSettings> iLogSettingsRepository)
    {
        _iLogSettingsRepository = iLogSettingsRepository;
    }

    public IQueryable<LogSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iLogSettingsRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<LogSettings> FindBy(Expression<Func<LogSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iLogSettingsRepository.FindBy(predicate, hasTracking);
    }

    public LogSettings GetById(long id)
    {
        return _iLogSettingsRepository.GetById(id);
    }

    public bool Exist(Expression<Func<LogSettings, bool>> predicate)
    {
        return _iLogSettingsRepository.Exist(predicate);
    }

    public void Create(LogSettings logSettings)
    {
        _iLogSettingsRepository.Create(logSettings);
    }

    public void Update(LogSettings logSettings)
    {
        _iLogSettingsRepository.Update(logSettings);
    }
}
