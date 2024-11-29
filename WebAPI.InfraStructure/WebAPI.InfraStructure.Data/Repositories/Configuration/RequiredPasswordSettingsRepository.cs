using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class RequiredPasswordSettingsRepository : IRequiredPasswordSettingsRepository
{
    private readonly IReadRepository<RequiredPasswordSettings> _iRequiredPasswordSettingsReadRepository;
    private readonly IWriteRepository<RequiredPasswordSettings> _iRequiredPasswordSettingsWriteRepository;

    public RequiredPasswordSettingsRepository(
        IReadRepository<RequiredPasswordSettings> iRequiredPasswordSettingsReadRepository,
        IWriteRepository<RequiredPasswordSettings> iRequiredPasswordSettingsWriteRepository
    )
    {
        _iRequiredPasswordSettingsReadRepository = iRequiredPasswordSettingsReadRepository;
        _iRequiredPasswordSettingsWriteRepository = iRequiredPasswordSettingsWriteRepository;
    }

    public IQueryable<RequiredPasswordSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iRequiredPasswordSettingsReadRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<RequiredPasswordSettings> FindBy(Expression<Func<RequiredPasswordSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iRequiredPasswordSettingsReadRepository.FindBy(predicate, hasTracking);
    }

    public RequiredPasswordSettings GetById(long id)
    {
        return _iRequiredPasswordSettingsReadRepository.GetById(id);
    }

    public bool Exist(Expression<Func<RequiredPasswordSettings, bool>> predicate)
    {
        return _iRequiredPasswordSettingsReadRepository.Exist(predicate);
    }

    public void Create(RequiredPasswordSettings requiredPasswordSettings)
    {
        _iRequiredPasswordSettingsWriteRepository.Create(requiredPasswordSettings);
    }

    public void Update(RequiredPasswordSettings requiredPasswordSettings)
    {
        _iRequiredPasswordSettingsWriteRepository.Update(requiredPasswordSettings);
    }
}
