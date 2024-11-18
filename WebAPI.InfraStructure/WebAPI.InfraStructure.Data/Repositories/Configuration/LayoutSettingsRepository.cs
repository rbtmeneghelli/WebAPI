using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class LayoutSettingsRepository : ILayoutSettingsRepository
{
    private readonly IGenericRepository<LayoutSettings> _iLayoutSettingsRepository;

    public LayoutSettingsRepository(IGenericRepository<LayoutSettings> iLayoutSettingsRepository)
    {
        _iLayoutSettingsRepository = iLayoutSettingsRepository;
    }

    public IQueryable<LayoutSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iLayoutSettingsRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<LayoutSettings> FindBy(Expression<Func<LayoutSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iLayoutSettingsRepository.FindBy(predicate, hasTracking);
    }

    public LayoutSettings GetById(long id)
    {
        return _iLayoutSettingsRepository.GetById(id);
    }

    public bool Exist(Expression<Func<LayoutSettings, bool>> predicate)
    {
        return _iLayoutSettingsRepository.Exist(predicate);
    }

    public void Create(LayoutSettings layoutSettings)
    {
        _iLayoutSettingsRepository.Create(layoutSettings);
    }

    public void Update(LayoutSettings layoutSettings)
    {
        _iLayoutSettingsRepository.Update(layoutSettings);
    }
}
