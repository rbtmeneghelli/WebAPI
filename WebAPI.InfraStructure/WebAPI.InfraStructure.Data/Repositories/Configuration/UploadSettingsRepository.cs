using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class UploadSettingsRepository : IUploadSettingsRepository
{
    private readonly IGenericReadRepository<UploadSettings> _iUploadSettingsReadRepository;
    private readonly IGenericWriteRepository<UploadSettings> _iUploadSettingsWriteRepository;

    public UploadSettingsRepository(
        IGenericReadRepository<UploadSettings> iUploadSettingsReadRepository,
        IGenericWriteRepository<UploadSettings> iUploadSettingsWriteRepository)
    {
        _iUploadSettingsReadRepository = iUploadSettingsReadRepository;
        _iUploadSettingsWriteRepository = iUploadSettingsWriteRepository;
    }

    public IQueryable<UploadSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iUploadSettingsReadRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<UploadSettings> FindBy(Expression<Func<UploadSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iUploadSettingsReadRepository.GetByPredicate(predicate, hasTracking);
    }

    public UploadSettings GetById(long id)
    {
        return _iUploadSettingsReadRepository.GetById(id);
    }

    public bool Exist(Expression<Func<UploadSettings, bool>> predicate)
    {
        return _iUploadSettingsReadRepository.Exist(predicate);
    }

    public void Create(UploadSettings uploadSettings)
    {
        _iUploadSettingsWriteRepository.Create(uploadSettings);
    }

    public void Update(UploadSettings uploadSettings)
    {
        _iUploadSettingsWriteRepository.Update(uploadSettings);
    }
}
