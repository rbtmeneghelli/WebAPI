using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class AuthenticationSettingsRepository : IAuthenticationSettingsRepository
{
    private readonly IGenericRepository<AuthenticationSettings> _iAuthenticationSettingsRepository;

    public AuthenticationSettingsRepository(IGenericRepository<AuthenticationSettings> iAuthenticationSettingsRepository)
    {
        _iAuthenticationSettingsRepository = iAuthenticationSettingsRepository;
    }
}
