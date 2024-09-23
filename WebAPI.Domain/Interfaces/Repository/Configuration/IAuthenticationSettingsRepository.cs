using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Interfaces.Repository.Configuration;

public interface IAuthenticationSettingsRepository
{
    IQueryable<AuthenticationSettings> GetAllInclude(string includeData, bool hasTracking = false);
}
