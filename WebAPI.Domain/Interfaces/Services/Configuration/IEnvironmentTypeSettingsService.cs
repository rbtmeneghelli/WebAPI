using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IEnvironmentTypeSettingsService
{
    Task<IEnumerable<EnvironmentTypeSettingsResponseDTO>> GetAllEnvironmentTypeSettingsAsync();
    Task<EnvironmentTypeSettingsResponseDTO> GetEnvironmentTypeSettingsByIdAsync(long id);
    Task<bool> ExistEnvironmentTypeSettingsByIdAsync(long id);
    Task<bool> CreateEnvironmentTypeSettingsAsync(EnvironmentTypeSettings environmentTypeSettings);
    Task<bool> UpdateEnvironmentTypeSettingsAsync(long id, EnvironmentTypeSettings environmentTypeSettings);
    Task<bool> LogicDeleteEnvironmentTypeSettingsByIdAsync(long id);
    Task<bool> ReactiveEnvironmentTypeSettingsByIdAsync(long id);
    Task<IEnumerable<EnvironmentTypeSettingsExcelDTO>> GetAllEnvironmentTypeSettingsExcelAsync();
}
