using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class EmailSettingsRepository : IEmailSettingsRepository
{
    private readonly IGenericRepository<EmailSettings> _iEmailSettingsRepository;

    public EmailSettingsRepository(IGenericRepository<EmailSettings> iEmailSettingsRepository)
    {
        _iEmailSettingsRepository = iEmailSettingsRepository;
    }

    public IQueryable<EmailSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iEmailSettingsRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<EmailSettings> FindBy(Expression<Func<EmailSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iEmailSettingsRepository.FindBy(predicate, hasTracking);
    }

    public EmailSettings GetById(long id)
    {
        return _iEmailSettingsRepository.GetById(id);
    }

    public bool Exist(Expression<Func<EmailSettings, bool>> predicate)
    {
        return _iEmailSettingsRepository.Exist(predicate);
    }

    public void Create(EmailSettings emailSettings)
    {
        _iEmailSettingsRepository.Create(emailSettings);
    }

    public void Update(EmailSettings emailSettings)
    {
        _iEmailSettingsRepository.Update(emailSettings);
    }
}
