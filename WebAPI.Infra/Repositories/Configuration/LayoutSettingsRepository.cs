using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Infra.Repositories.Configuration;

public class LayoutSettingsRepository : ILayoutSettingsRepository
{
    private readonly IGenericRepository<LayoutSettings> _iLayoutSettingsRepository;

    public LayoutSettingsRepository(IGenericRepository<LayoutSettings> iLayoutSettingsRepository)
    {
        _iLayoutSettingsRepository = iLayoutSettingsRepository;
    }
}
