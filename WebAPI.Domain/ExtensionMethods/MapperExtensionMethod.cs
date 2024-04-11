using WebAPI.Domain.DTO;
using WebAPI.Domain.Entities;

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
            IdProfile = user.IdProfile,
            Status = user.GetStatus()
        };
    }
}
