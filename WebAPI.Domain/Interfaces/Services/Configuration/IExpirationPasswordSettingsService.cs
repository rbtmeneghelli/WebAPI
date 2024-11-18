using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IExpirationPasswordSettingsService
{
    Task<IEnumerable<ExpirationPasswordSettingsResponseDTO>> GetAllExpirationPasswordSettingsAsync();
    Task<ExpirationPasswordSettingsResponseDTO> GetExpirationPasswordSettingsByEnvironmentAsync();
    Task<ExpirationPasswordSettingsResponseDTO> GetExpirationPasswordSettingsByIdAsync(long id);
    Task<bool> ExistExpirationPasswordSettingsByEnvironmentAsync();
    Task<bool> ExistExpirationPasswordSettingsByIdAsync(long id);
    Task<bool> CreateExpirationPasswordSettingsAsync(ExpirationPasswordSettings expirationPasswordSettings);
    Task<bool> UpdateExpirationPasswordSettingsAsync(ExpirationPasswordSettings expirationPasswordSettings);
    Task<bool> LogicDeleteExpirationPasswordSettingsByIdAsync(long id);
    Task<bool> ReactiveExpirationPasswordSettingsByIdAsync(long id);
    Task<IEnumerable<ExpirationPasswordSettingsExcelDTO>> GetAllExpirationPasswordSettingsExcelAsync();
}
