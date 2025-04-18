using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.InfraStructure.Data.Repositories.Configuration;

public class AuthenticationSettingsRepository : IAuthenticationSettingsRepository
{
    private readonly IGenericReadRepository<AuthenticationSettings> _iAuthenticationSettingsReadRepository;
    private readonly IGenericWriteRepository<AuthenticationSettings> _iAuthenticationSettingsWriteRepository;

    public AuthenticationSettingsRepository(
        IGenericReadRepository<AuthenticationSettings> iAuthenticationSettingsReadRepository,
         IGenericWriteRepository<AuthenticationSettings> iAuthenticationSettingsWriteRepository
        )
    {
        _iAuthenticationSettingsReadRepository = iAuthenticationSettingsReadRepository;
        _iAuthenticationSettingsWriteRepository = iAuthenticationSettingsWriteRepository;
    }

    public IQueryable<AuthenticationSettings> GetAllInclude(string includeData, bool hasTracking = false)
    {
        return _iAuthenticationSettingsReadRepository.GetAllInclude(includeData, hasTracking);
    }

    public IQueryable<AuthenticationSettings> FindBy(Expression<Func<AuthenticationSettings, bool>> predicate, bool hasTracking = false)
    {
        return _iAuthenticationSettingsReadRepository.GetByPredicate(predicate, hasTracking);
    }

    public AuthenticationSettings GetById(long id)
    {
        return _iAuthenticationSettingsReadRepository.GetById(id);
    }

    public bool Exist(Expression<Func<AuthenticationSettings, bool>> predicate)
    {
        return _iAuthenticationSettingsReadRepository.Exist(predicate);
    }

    public void Create(AuthenticationSettings authenticationSettings)
    {
        _iAuthenticationSettingsWriteRepository.Create(authenticationSettings);
    }

    public void Update(AuthenticationSettings authenticationSettings)
    {
        _iAuthenticationSettingsWriteRepository.Update(authenticationSettings);
    }
}
