using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IEnvironmentTypeSettingsService
{
    Task<IEnumerable<EnvironmentTypeSettingsResponseDTO>> GetAllEnvironmentTypeSettingsAsync();
    Task<EnvironmentTypeSettingsResponseDTO> GetEnvironmentTypeSettingsByIdAsync(long id);
    Task<bool> ExistEnvironmentTypeSettingsByIdAsync(long id);
    Task<bool> CreateEnvironmentTypeSettingsAsync(EnvironmentTypeSettingsCreateRequestDTO environmentTypeSettingsCreateRequestDTO);
    Task<bool> UpdateEnvironmentTypeSettingsAsync(EnvironmentTypeSettingsUpdateRequestDTO environmentTypeSettingsUpdateRequestDTO);
    Task<bool> LogicDeleteEnvironmentTypeSettingsByIdAsync(long id);
    Task<bool> ReactiveEnvironmentTypeSettingsByIdAsync(long id);
    Task<IEnumerable<EnvironmentTypeSettingsExcelDTO>> GetAllEnvironmentTypeSettingsExcelAsync();
}
