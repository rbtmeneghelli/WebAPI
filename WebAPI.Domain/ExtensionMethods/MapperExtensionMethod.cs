using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Domain.ExtensionMethods;

/// <summary>
/// Exemplo de AutoMapper, sem utilizar a biblioteca de AutoMapper
/// </summary>
public static class MapperExtensionMethod
{
    #region Mapeamento da Entidade EnvironmentTypeSettings para modelos DTO

    public static UserResponseDTO ToDTO(this User user)
    {
        return new UserResponseDTO
        {
            Id = user.Id,
            Login = user.Login,
            IsAuthenticated = user.IsAuthenticated,
            IsActive = user.Status,
            Password = "-",
            LastPassword = "-",
            Employee = user.Employee.Name,
            Profile = user.Employee.Profile.Description,
            Status = user.GetStatusDescription(),
        };
    }

    public static IEnumerable<UserResponseDTO> ToDTO(this IEnumerable<User> users)
    {
        if (users is not null)
            return users.Select(p => p.ToDTO());
        else
            return Enumerable.Empty<UserResponseDTO>();
    }

    #endregion

    #region Mapeamento da Entidade EnvironmentTypeSettings para modelos DTO

    public static EnvironmentTypeSettingsResponseDTO ToDTO(this EnvironmentTypeSettings environmentTypeSettings)
    {
        return new EnvironmentTypeSettingsResponseDTO
        {
            Id = environmentTypeSettings.Id.Value,
            EnvironmentDescription = environmentTypeSettings.Description,
            EnvironmentInitial = environmentTypeSettings.Initials,
            StatusDescription = environmentTypeSettings.GetStatusDescription()
        };
    }

    public static IEnumerable<EnvironmentTypeSettingsResponseDTO> ToDTO(this IEnumerable<EnvironmentTypeSettings> environmentTypeSettings)
    {
        if (environmentTypeSettings is not null)
            return environmentTypeSettings.Select(p => p.ToDTO());
        else
            return Enumerable.Empty<EnvironmentTypeSettingsResponseDTO>();
    }

    public static IEnumerable<EnvironmentTypeSettingsExcelDTO> ToExcel(this IEnumerable<EnvironmentTypeSettings> environmentTypeSettings)
    {
        if (environmentTypeSettings is not null)
            return environmentTypeSettings.Select(p => new EnvironmentTypeSettingsExcelDTO
            {
                EnvironmentDescription = p.Description,
                EnvironmentInitial = p.Initials,
                StatusDescription = p.GetStatusDescription()
            }).ToList();
        else
            return Enumerable.Empty<EnvironmentTypeSettingsExcelDTO>();
    }

    #endregion
}
