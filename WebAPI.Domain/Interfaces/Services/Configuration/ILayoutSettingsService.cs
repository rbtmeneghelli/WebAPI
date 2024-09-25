using WebAPI.Domain.EntitiesDTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface ILayoutSettingsService
{
    Task<bool> CreateUploadSettingsRequestDTO(LayoutSettingsCreateRequestDTO layoutSettingsCreateRequestDTO);
    Task<bool> UpdateUploadSettingsRequestDTO(LayoutSettingsUpdateRequestDTO layoutSettingsUpdateRequestDTO);
}
