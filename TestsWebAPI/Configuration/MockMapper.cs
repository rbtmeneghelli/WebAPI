using FastPackForShare.Enums;
using FastPackForShare.Extensions;
using FastPackForShare.Interfaces;
using Moq;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Entities.ControlPanel;

namespace TestsWebAPI.Configuration;

public static class MockMapper
{
    public static Mock<IMapperService> Create(Mock<IMapperService> mockMapperService)
    {
        mockMapperService = new Mock<IMapperService>();

        mockMapperService.Setup(m => m.MapDTOToEntity<UserRequestCreateDTO, User>(It.IsAny<UserRequestCreateDTO>()))
        .Returns(
        new User
        {
            Login = "XPTO",
            Password = "1234Mudar",
            IsActive = true,
            IsAuthenticated = true,
            CreatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil(),
            HasTwoFactoryValidation = false
        });

        mockMapperService.Setup(m => m.MapDTOToEntity<UserRequestUpdateDTO, User>(It.IsAny<UserRequestUpdateDTO>()))
        .Returns(
        new User
        {
            Id = 999999,
            Login = "Usuario",
            Password = "123Mudar",
            IsActive = true,
            IsAuthenticated = true,
            UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil(),
            HasTwoFactoryValidation = false
        });

        mockMapperService.Setup(m => m.MapEntityToDTO<User, UserResponseDTO>(It.IsAny<User>()))
        .Returns(new UserResponseDTO
        {
            Id = 999999,
            Login = "XPTO",
            Password = "1234Mudar",
            IsActive = true,
            IsAuthenticated = true,
            Employee = "Teste",
            Profile = "Perfil",
            Status = EnumStatus.Active.GetDisplayName()
        });


        mockMapperService.Setup(m => m.MapEntityToDTOList<IEnumerable<User>, IEnumerable<UserResponseDTO>>(It.IsAny<IEnumerable<User>>()))
        .Returns(new List<UserResponseDTO>
        {
            new UserResponseDTO
            {
                Id = 999999,
                Login = "XPTO",
                Password = "1234Mudar",
                IsActive = true,
                IsAuthenticated = true,
                Employee = "Teste",
                Profile = "Perfil",
                Status = EnumStatus.Active.GetDisplayName()
            }
        });

        return mockMapperService;
    }
}