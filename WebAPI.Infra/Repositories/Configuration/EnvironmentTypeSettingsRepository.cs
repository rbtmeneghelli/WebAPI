using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class EnvironmentTypeSettingsRepository : IEnvironmentTypeSettingsRepository
{
    private readonly IGenericRepository<EnvironmentTypeSettings> _iEnvironmentTypeSettingsRepository;

    public EnvironmentTypeSettingsRepository(IGenericRepository<EnvironmentTypeSettings> iEnvironmentTypeSettingsRepository)
    {
        _iEnvironmentTypeSettingsRepository = iEnvironmentTypeSettingsRepository;
    }
}
