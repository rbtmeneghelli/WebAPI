using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IEmailDisplaySettingsService
{
    Task<IEnumerable<EmailDisplaySettingsResponseDTO>> GetAllEmailDisplaySettingsAsync();
    Task<EmailDisplaySettingsResponseDTO> GetEmailDisplaySettingsByIdAsync(long id);
    Task<bool> ExistEmailDisplaySettingsByIdAsync(long id);
    Task<bool> CreateEmailDisplaySettingsAsync(EmailDisplay requiredPasswordSettings);
    Task<bool> UpdateEmailDisplaySettingsAsync(long id, EmailDisplay requiredPasswordSettings);
    Task<bool> LogicDeleteEmailDisplaySettingsByIdAsync(long id);
    Task<bool> ReactiveEmailDisplaySettingsByIdAsync(long id);
    Task<IEnumerable<EmailDisplaySettingsExcelDTO>> GetAllEmailDisplaySettingsExcelAsync();
}
