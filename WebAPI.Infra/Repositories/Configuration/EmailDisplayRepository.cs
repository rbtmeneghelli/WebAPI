using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class EmailDisplaySettingsRepository : IEmailDisplaySettingsRepository
{
    private readonly IGenericRepository<EmailDisplay> _iEmailDisplayRepository;

    public EmailDisplaySettingsRepository(IGenericRepository<EmailDisplay> iEmailDisplayRepository)
    {
        _iEmailDisplayRepository = iEmailDisplayRepository;
    }

    public IQueryable<EmailDisplay> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iEmailDisplayRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<EmailDisplay> FindBy(Expression<Func<EmailDisplay, bool>> predicate, bool hasTracking = false)
    {
        return _iEmailDisplayRepository.FindBy(predicate, hasTracking);
    }

    public EmailDisplay GetById(long id)
    {
        return _iEmailDisplayRepository.GetById(id);
    }

    public bool Exist(Expression<Func<EmailDisplay, bool>> predicate)
    {
        return _iEmailDisplayRepository.Exist(predicate);
    }

    public void Create(EmailDisplay emailDisplay)
    {
        _iEmailDisplayRepository.Create(emailDisplay);
    }

    public void Update(EmailDisplay emailDisplay)
    {
        _iEmailDisplayRepository.Update(emailDisplay);
    }
}
