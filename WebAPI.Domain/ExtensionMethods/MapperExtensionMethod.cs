using WebAPI.Domain.EntitiesDTO;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Domain.ExtensionMethods;

/// <summary>
/// Exemplo de AutoMapper, sem utilizar a biblioteca de AutoMapper
/// </summary>
public static class MapperExtensionMethod
{
    public static UserResponseDTO AsUserReturnedDTO(this User user)
    {
        return new UserResponseDTO
        {
            Login = user.Login,
            Password = "XXXX",
            LastPassword = "XPTO",
            IsAuthenticated = user.IsAuthenticated,
            Status = user.GetIsActiveDescription()
        };
    }
}
