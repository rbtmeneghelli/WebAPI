using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class EmailDisplaySettingsRepository : IEmailDisplaySettingsRepository
{
    private readonly IGenericReadRepository<EmailDisplay> _iEmailDisplayReadRepository;
    private readonly IGenericWriteRepository<EmailDisplay> _iEmailDisplayWriteRepository;

    public EmailDisplaySettingsRepository(
        IGenericReadRepository<EmailDisplay> iEmailDisplayReadRepository,
        IGenericWriteRepository<EmailDisplay> iEmailDisplayWriteRepository)
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
        return _iEmailDisplayReadRepository.GetByPredicate(predicate, hasTracking);
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
