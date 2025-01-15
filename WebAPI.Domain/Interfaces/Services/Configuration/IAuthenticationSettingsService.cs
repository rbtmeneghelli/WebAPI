using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IAuthenticationSettingsService
{
    Task<IEnumerable<AuthenticationSettingsResponseDTO>> GetAllAuthenticationSettingsAsync();
    Task<AuthenticationSettingsResponseDTO> GetAuthenticationSettingsByEnvironmentAsync();
    Task<AuthenticationSettingsResponseDTO> GetAuthenticationSettingsByIdAsync(long id);
    Task<bool> ExistAuthenticationSettingsByEnvironmentAsync();
    Task<bool> ExistAuthenticationSettingsByIdAsync(long id);
    Task<bool> CreateAuthenticationSettingsAsync(AuthenticationSettingsCreateRequestDTO authenticationSettingsCreateRequestDTO);
    Task<bool> UpdateAuthenticationSettingsAsync(AuthenticationSettingsUpdateRequestDTO authenticationSettingsCreateRequestDTO);
    Task<bool> LogicDeleteAuthenticationSettingsByIdAsync(long id);
    Task<bool> ReactiveAuthenticationSettingsByIdAsync(long id);
    Task<IEnumerable<AuthenticationSettingsExcelDTO>> GetAllAuthenticationSettingsExcelAsync();
}
