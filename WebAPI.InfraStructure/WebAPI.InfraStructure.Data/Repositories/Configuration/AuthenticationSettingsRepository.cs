using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class AuthenticationSettingsRepository : IAuthenticationSettingsRepository
{
    private readonly IGenericRepository<AuthenticationSettings> _iAuthenticationSettingsRepository;

    public AuthenticationSettingsRepository(IGenericRepository<AuthenticationSettings> iAuthenticationSettingsRepository)
    {
        _iAuthenticationSettingsRepository = iAuthenticationSettingsRepository;
    }

    public IQueryable<AuthenticationSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iAuthenticationSettingsRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<AuthenticationSettings> FindBy(Expression<Func<AuthenticationSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iAuthenticationSettingsRepository.FindBy(predicate, hasTracking);
    }

    public AuthenticationSettings GetById(long id)
    {
        return _iAuthenticationSettingsRepository.GetById(id);
    }

    public bool Exist(Expression<Func<AuthenticationSettings, bool>> predicate)
    {
        return _iAuthenticationSettingsRepository.Exist(predicate);
    }

    public void Create(AuthenticationSettings authenticationSettings)
    {
        _iAuthenticationSettingsRepository.Create(authenticationSettings);
    }

    public void Update(AuthenticationSettings authenticationSettings)
    {
        _iAuthenticationSettingsRepository.Update(authenticationSettings);
    }
}
