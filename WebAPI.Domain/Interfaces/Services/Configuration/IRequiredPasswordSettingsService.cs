using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IRequiredPasswordSettingsService
{
    Task<IEnumerable<RequiredPasswordSettingsResponseDTO>> GetAllRequiredPasswordSettingsAsync();
    Task<RequiredPasswordSettingsResponseDTO> GetRequiredPasswordSettingsByEnvironmentAsync();
    Task<RequiredPasswordSettingsResponseDTO> GetRequiredPasswordSettingsByIdAsync(long id);
    Task<bool> ExistRequiredPasswordSettingsByEnvironmentAsync();
    Task<bool> ExistRequiredPasswordSettingsByIdAsync(long id);
    Task<bool> CreateRequiredPasswordSettingsAsync(RequiredPasswordSettings requiredPasswordSettings);
    Task<bool> UpdateRequiredPasswordSettingsAsync(RequiredPasswordSettings requiredPasswordSettings);
    Task<bool> LogicDeleteRequiredPasswordSettingsByIdAsync(long id);
    Task<bool> ReactiveRequiredPasswordSettingsByIdAsync(long id);
    Task<IEnumerable<RequiredPasswordSettingsExcelDTO>> GetAllRequiredPasswordSettingsExcelAsync();
}
