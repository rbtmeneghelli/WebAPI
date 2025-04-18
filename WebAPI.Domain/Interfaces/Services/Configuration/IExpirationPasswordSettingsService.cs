using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IExpirationPasswordSettingsService
{
    Task<IEnumerable<ExpirationPasswordSettingsResponseDTO>> GetAllExpirationPasswordSettingsAsync();
    Task<ExpirationPasswordSettingsResponseDTO> GetExpirationPasswordSettingsByEnvironmentAsync();
    Task<ExpirationPasswordSettingsResponseDTO> GetExpirationPasswordSettingsByIdAsync(long id);
    Task<bool> ExistExpirationPasswordSettingsByEnvironmentAsync();
    Task<bool> ExistExpirationPasswordSettingsByIdAsync(long id);
    Task<bool> CreateExpirationPasswordSettingsAsync(ExpirationPasswordSettingsCreateRequestDTO expirationPasswordSettingsCreateRequestDTO);
    Task<bool> UpdateExpirationPasswordSettingsAsync(ExpirationPasswordSettingsUpdateRequestDTO expirationPasswordSettingsUpdateRequestDTO);
    Task<bool> LogicDeleteExpirationPasswordSettingsByIdAsync(long id);
    Task<bool> ReactiveExpirationPasswordSettingsByIdAsync(long id);
    Task<IEnumerable<ExpirationPasswordSettingsExcelDTO>> GetAllExpirationPasswordSettingsExcelAsync();
}
