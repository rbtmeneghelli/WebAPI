using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class LayoutSettingsRepository : ILayoutSettingsRepository
{
    private readonly IReadRepository<LayoutSettings> _iLayoutSettingsReadRepository;
    private readonly IWriteRepository<LayoutSettings> _iLayoutSettingsWriteRepository;

    public LayoutSettingsRepository(
        IReadRepository<LayoutSettings> iLayoutSettingsReadRepository,
        IWriteRepository<LayoutSettings> iLayoutSettingsWriteRepository)
    {
        _iLayoutSettingsReadRepository = iLayoutSettingsReadRepository;
        _iLayoutSettingsWriteRepository = iLayoutSettingsWriteRepository;
    }

    public IQueryable<LayoutSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iLayoutSettingsReadRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<LayoutSettings> FindBy(Expression<Func<LayoutSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iLayoutSettingsReadRepository.GetByPredicate(predicate, hasTracking);
    }

    public LayoutSettings GetById(long id)
    {
        return _iLayoutSettingsReadRepository.GetById(id);
    }

    public bool Exist(Expression<Func<LayoutSettings, bool>> predicate)
    {
        return _iLayoutSettingsReadRepository.Exist(predicate);
    }

    public void Create(LayoutSettings layoutSettings)
    {
        _iLayoutSettingsWriteRepository.Create(layoutSettings);
    }

    public void Update(LayoutSettings layoutSettings)
    {
        _iLayoutSettingsWriteRepository.Update(layoutSettings);
    }
}
