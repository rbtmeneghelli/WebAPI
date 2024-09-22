using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class RequiredPasswordSettingsRepository : IRequiredPasswordSettingsRepository
{
    private readonly IGenericRepository<RequiredPasswordSettings> _iRequiredPasswordSettingsRepository;

    public RequiredPasswordSettingsRepository(IGenericRepository<RequiredPasswordSettings> iRequiredPasswordSettingsRepository)
    {
        _iRequiredPasswordSettingsRepository = iRequiredPasswordSettingsRepository;
    }
}
