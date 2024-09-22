using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class ExpirationPasswordSettingsRepository : IExpirationPasswordSettingsRepository
{
    private readonly IGenericRepository<ExpirationPasswordSettings> _iExpirationPasswordSettingsRepository;

    public ExpirationPasswordSettingsRepository(IGenericRepository<ExpirationPasswordSettings> iExpirationPasswordSettingsRepository)
    {
        _iExpirationPasswordSettingsRepository = iExpirationPasswordSettingsRepository;
    }
}
