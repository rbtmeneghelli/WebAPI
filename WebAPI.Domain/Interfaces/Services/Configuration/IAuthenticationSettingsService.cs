using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IAuthenticationSettingsService
{
    Task<IEnumerable<AuthenticationSettingsResponseDTO>> GetAllAuthenticationSettingsAsync();
    Task<AuthenticationSettingsResponseDTO> GetAuthenticationSettingsByEnvironmentAsync();
    Task<AuthenticationSettingsResponseDTO> GetAuthenticationSettingsByIdAsync(long id);
    Task<bool> ExistAuthenticationSettingsByEnvironmentAsync();
    Task<bool> ExistAuthenticationSettingsByIdAsync(long id);
    Task<bool> CreateAuthenticationSettingsAsync(AuthenticationSettings authenticationSettings);
    Task<bool> UpdateAuthenticationSettingsAsync(long id, AuthenticationSettings authenticationSettings);
    Task<bool> LogicDeleteAuthenticationSettingsByIdAsync(long id);
    Task<bool> ReactiveAuthenticationSettingsByIdAsync(long id);
    Task<IEnumerable<AuthenticationSettingsExcelDTO>> GetAllAuthenticationSettingsExcelAsync();
}
