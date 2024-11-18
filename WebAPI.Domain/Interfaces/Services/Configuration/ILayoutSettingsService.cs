using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;

public interface ILayoutSettingsService
{
    Task<IEnumerable<LayoutSettingsResponseDTO>> GetAllLayoutSettingsAsync();
    Task<LayoutSettingsResponseDTO> GetLayoutSettingsByEnvironmentAsync();
    Task<LayoutSettingsResponseDTO> GetLayoutSettingsByIdAsync(long id);
    Task<bool> ExistLayoutSettingsByEnvironmentAsync();
    Task<bool> ExistLayoutSettingsByIdAsync(long id);
    Task<bool> CreateLayoutSettingsAsync(LayoutSettings requiredPasswordSettings);
    Task<bool> UpdateLayoutSettingsAsync(LayoutSettings requiredPasswordSettings);
    Task<bool> LogicDeleteLayoutSettingsByIdAsync(long id);
    Task<bool> ReactiveLayoutSettingsByIdAsync(long id);
    Task<IEnumerable<LayoutSettingsExcelDTO>> GetAllLayoutSettingsExcelAsync();
}