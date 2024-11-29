using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class EmailDisplaySettingsRepository : IEmailDisplaySettingsRepository
{
    private readonly IReadRepository<EmailDisplay> _iEmailDisplayReadRepository;
    private readonly IWriteRepository<EmailDisplay> _iEmailDisplayWriteRepository;

    public EmailDisplaySettingsRepository(
        IReadRepository<EmailDisplay> iEmailDisplayReadRepository,
        IWriteRepository<EmailDisplay> iEmailDisplayWriteRepository)
    {
        _iEmailDisplayReadRepository = iEmailDisplayReadRepository;
        _iEmailDisplayWriteRepository = iEmailDisplayWriteRepository;
    }

    public IQueryable<EmailDisplay> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iEmailDisplayReadRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<EmailDisplay> FindBy(Expression<Func<EmailDisplay, bool>> predicate, bool hasTracking = false)
    {
        return _iEmailDisplayReadRepository.FindBy(predicate, hasTracking);
    }

    public EmailDisplay GetById(long id)
    {
        return _iEmailDisplayReadRepository.GetById(id);
    }

    public bool Exist(Expression<Func<EmailDisplay, bool>> predicate)
    {
        return _iEmailDisplayReadRepository.Exist(predicate);
    }

    public void Create(EmailDisplay emailDisplay)
    {
        _iEmailDisplayWriteRepository.Create(emailDisplay);
    }

    public void Update(EmailDisplay emailDisplay)
    {
        _iEmailDisplayWriteRepository.Update(emailDisplay);
    }
}
