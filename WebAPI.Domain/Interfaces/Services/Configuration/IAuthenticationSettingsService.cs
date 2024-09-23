using WebAPI.Domain.EntitiesDTO.Configuration;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IAuthenticationSettingsService
{
    Task<IEnumerable<AuthenticationSettingsResponseDTO>> GetAllAsync();
}
