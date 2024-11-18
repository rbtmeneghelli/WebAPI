using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class UploadSettingsRepository : IUploadSettingsRepository
{
    private readonly IGenericRepository<UploadSettings> _iUploadSettingsRepository;

    public UploadSettingsRepository(IGenericRepository<UploadSettings> iUploadSettingsRepository)
    {
        _iUploadSettingsRepository = iUploadSettingsRepository;
    }

    public IQueryable<UploadSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iUploadSettingsRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<UploadSettings> FindBy(Expression<Func<UploadSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iUploadSettingsRepository.FindBy(predicate, hasTracking);
    }

    public UploadSettings GetById(long id)
    {
        return _iUploadSettingsRepository.GetById(id);
    }

    public bool Exist(Expression<Func<UploadSettings, bool>> predicate)
    {
        return _iUploadSettingsRepository.Exist(predicate);
    }

    public void Create(UploadSettings uploadSettings)
    {
        _iUploadSettingsRepository.Create(uploadSettings);
    }

    public void Update(UploadSettings uploadSettings)
    {
        _iUploadSettingsRepository.Update(uploadSettings);
    }
}
