using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IEmailDisplaySettingsService
{
    Task<IEnumerable<EmailDisplaySettingsResponseDTO>> GetAllEmailDisplaySettingsAsync();
    Task<EmailDisplaySettingsResponseDTO> GetEmailDisplaySettingsByIdAsync(long id);
    Task<bool> ExistEmailDisplaySettingsByIdAsync(long id);
    Task<bool> CreateEmailDisplaySettingsAsync(EmailDisplaySettingsCreateRequestDTO emailDisplaySettingsCreateRequestDTO);
    Task<bool> UpdateEmailDisplaySettingsAsync(EmailDisplaySettingsUpdateRequestDTO emailDisplaySettingsCreateRequestDTO);
    Task<bool> LogicDeleteEmailDisplaySettingsByIdAsync(long id);
    Task<bool> ReactiveEmailDisplaySettingsByIdAsync(long id);
    Task<IEnumerable<EmailDisplaySettingsExcelDTO>> GetAllEmailDisplaySettingsExcelAsync();
}
