using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class RequiredPasswordSettingsRepository : IRequiredPasswordSettingsRepository
{
    private readonly IGenericRepository<RequiredPasswordSettings> _iRequiredPasswordSettingsRepository;

    public RequiredPasswordSettingsRepository(IGenericRepository<RequiredPasswordSettings> iRequiredPasswordSettingsRepository)
    {
        _iRequiredPasswordSettingsRepository = iRequiredPasswordSettingsRepository;
    }

    public IQueryable<RequiredPasswordSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iRequiredPasswordSettingsRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<RequiredPasswordSettings> FindBy(Expression<Func<RequiredPasswordSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iRequiredPasswordSettingsRepository.FindBy(predicate, hasTracking);
    }

    public RequiredPasswordSettings GetById(long id)
    {
        return _iRequiredPasswordSettingsRepository.GetById(id);
    }

    public bool Exist(Expression<Func<RequiredPasswordSettings, bool>> predicate)
    {
        return _iRequiredPasswordSettingsRepository.Exist(predicate);
    }

    public void Create(RequiredPasswordSettings requiredPasswordSettings)
    {
        _iRequiredPasswordSettingsRepository.Create(requiredPasswordSettings);
    }

    public void Update(RequiredPasswordSettings requiredPasswordSettings)
    {
        _iRequiredPasswordSettingsRepository.Update(requiredPasswordSettings);
    }
}
