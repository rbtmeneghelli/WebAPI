using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class LogSettingsRepository : ILogSettingsRepository
{
    private readonly IGenericRepository<LogSettings> _iLogSettingsRepository;

    public LogSettingsRepository(IGenericRepository<LogSettings> iLogSettingsRepository)
    {
        _iLogSettingsRepository = iLogSettingsRepository;
    }
}
