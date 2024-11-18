using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IUploadSettingsService
{
    Task<UploadSettingsResponseDTO> GetUploadSettingsByEnvironmentAsync();
    Task<UploadSettingsResponseDTO> GetUploadSettingsByIdAsync(long id);
    Task<bool> ExistUploadSettingsByEnvironmentAsync();
    Task<bool> ExistUploadSettingsByIdAsync(long id);
    Task<bool> CreateUploadSettingsAsync(UploadSettingsCreateRequestDTO uploadSettingsCreateRequestDTO);
    Task<bool> UpdateUploadSettingsAsync(UploadSettingsUpdateRequestDTO uploadSettingsUpdateRequestDTO);
    Task<bool> LogicDeleteUploadSettingsByIdAsync(long id);
    Task<bool> ReactiveUploadSettingsByIdAsync(long id);
}

