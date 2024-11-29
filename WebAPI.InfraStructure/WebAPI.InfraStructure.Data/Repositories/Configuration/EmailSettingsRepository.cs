using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class EmailSettingsRepository : IEmailSettingsRepository
{
    private readonly IReadRepository<EmailSettings> _iEmailSettingsReadRepository;
    private readonly IWriteRepository<EmailSettings> _iEmailSettingsWriteRepository;

    public EmailSettingsRepository(
        IReadRepository<EmailSettings> iEmailSettingsReadRepository,
        IWriteRepository<EmailSettings> iEmailSettingsWriteRepository)
    {
        _iEmailSettingsReadRepository = iEmailSettingsReadRepository;
        _iEmailSettingsWriteRepository = iEmailSettingsWriteRepository;
    }

    public IQueryable<EmailSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iEmailSettingsReadRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<EmailSettings> FindBy(Expression<Func<EmailSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iEmailSettingsReadRepository.FindBy(predicate, hasTracking);
    }

    public EmailSettings GetById(long id)
    {
        return _iEmailSettingsReadRepository.GetById(id);
    }

    public bool Exist(Expression<Func<EmailSettings, bool>> predicate)
    {
        return _iEmailSettingsReadRepository.Exist(predicate);
    }

    public void Create(EmailSettings emailSettings)
    {
        _iEmailSettingsWriteRepository.Create(emailSettings);
    }

    public void Update(EmailSettings emailSettings)
    {
        _iEmailSettingsWriteRepository.Update(emailSettings);
    }
}
