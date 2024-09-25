using WebAPI.Domain.EntitiesDTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface ILayoutSettingsService
{
    Task<bool> CreateLayoutSettingsRequestDTO(LayoutSettingsCreateRequestDTO layoutSettingsCreateRequestDTO);
    Task<bool> UpdateLayoutSettingsRequestDTO(LayoutSettingsUpdateRequestDTO layoutSettingsUpdateRequestDTO);
}
