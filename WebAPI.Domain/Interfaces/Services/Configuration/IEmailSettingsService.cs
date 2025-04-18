using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IEmailSettingsService
{
    Task<IEnumerable<EmailSettingsResponseDTO>> GetAllEmailSettingsAsync();
    Task<EmailSettingsResponseDTO> GetEmailSettingsByEnvironmentAsync();
    Task<EmailSettingsResponseDTO> GetEmailSettingsByIdAsync(long id);
    Task<bool> ExistEmailSettingsByEnvironmentAsync();
    Task<bool> ExistEmailSettingsByIdAsync(long id);
    Task<bool> CreateEmailSettingsAsync(EmailSettingsCreateRequestDTO emailSettingsCreateRequestDTO);
    Task<bool> UpdateEmailSettingsAsync(EmailSettingsUpdateRequestDTO emailSettingsUpdateRequestDTO);
    Task<bool> LogicDeleteEmailSettingsByIdAsync(long id);
    Task<bool> ReactiveEmailSettingsByIdAsync(long id);
    Task<IEnumerable<EmailSettingsExcelDTO>> GetAllEmailSettingsExcelAsync();
}
