using AutoMapper;
using FastPackForShare.Constants;
using FastPackForShare.Default;
using FastPackForShare.Enums;
using FastPackForShare.Extensions;
using FastPackForShare.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using WebAPI.Application.Services;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel.Users;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.V1.Controllers;

namespace TestsWebAPI;

public sealed class CRUDTestService
{
    private AutoMocker _mocker;
    private UserService _userService;
    private Mock<IMapper> _mockMapper;
    private Mock<IMapperService> _mockMapperService;
    private Mock<INotificationMessageService> _mockNotificationMessageService;

    public CRUDTestService()
    {
        _mocker = new AutoMocker();
        _mockMapperService = MockMapper.Create(_mockMapperService);
        _mockNotificationMessageService = new Mock<INotificationMessageService>();

        _mocker.Use(_mockMapperService.Object);
        _mocker.Use(_mockNotificationMessageService.Object);
        _userService = _mocker.CreateInstance<UserService>();

        _mocker.GetMock<IUserRepository>()
        .Setup(p => p.Add(It.IsAny<User>()));

        _mocker.GetMock<IUserRepository>()
        .Setup(p => p.Update(It.IsAny<User>()));

        _mocker.GetMock<IUserRepository>()
        .Setup(p => p.Remove(It.IsAny<User>()));

        _mocker.GetMock<IUserRepository>()
        .Setup(p => p.GetById(It.IsAny<long>()))
        .Returns(new User
        {
            Id = 999999,
            Login = "XPTO",
            Password = "123456Mudar",
            IsActive = true,
            IsAuthenticated = true,
            UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil(),
            HasTwoFactoryValidation = false
        });

        _mocker.GetMock<IUserRepository>()
       .Setup(p => p.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

        _mocker.GetMock<IUserRepository>()
        .Setup(p => p.FindBy(It.IsAny<Expression<Func<User, bool>>>()))
        .Returns(new List<User>()
        {
            new User
            {
            Id = 999999,
            Login = "XPTO",
            Password = "123456Mudar",
            IsActive = true,
            IsAuthenticated = true,
            UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil(),
            HasTwoFactoryValidation = false
            }
        }.AsQueryable());

        _mocker.GetMock<IUserRepository>()
        .Setup(p => p.GetAll(It.IsAny<bool>()))
        .Returns(new List<User>()
        {
            new User
            {
            Id = 999999,
            Login = "XPTO",
            Password = "123456Mudar",
            IsActive = true,
            IsAuthenticated = true,
            UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil(),
            HasTwoFactoryValidation = false
            }
        }.AsQueryable());

        _mocker.GetMock<IUserRepository>()
        .Setup(p => p.GetAllIgnoreQueryFilter(It.IsAny<bool>()))
        .Returns(new List<User>()
        {
                    new User
                    {
                    Id = 999999,
                    Login = "XPTO",
                    Password = "123456Mudar",
                    IsActive = true,
                    IsAuthenticated = true,
                    UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil(),
                    HasTwoFactoryValidation = false
                    }
        }.AsQueryable());

        _mocker.GetMock<IUserRepository>()
        .Setup(p => p.CanDelete(It.IsAny<long>())).ReturnsAsync(true);
    }

    [Fact(DisplayName = "Metodo para cadastrar")]
    public async Task Create()
    {
        // Arrange
        UserRequestCreateDTO userRequestCreateDTO = new UserRequestCreateDTO
        {
            Login = "XPTO",
            Password = "1234Mudar",
            IsActive = true,
            IsAuthenticated = true,
        };

        // Act
        var result = await _userService.CreateUserAsync(userRequestCreateDTO);

        // Assert
        Assert.True(result);
    }

    [Fact(DisplayName = "Metodo para atualizar, a partir do seu ID")]
    public async Task Update()
    {
        // Arrange
        UserRequestUpdateDTO userRequestUpdateDTO = new UserRequestUpdateDTO
        {
            Id = 999999,
            Login = "Usuario",
            Password = "123Mudar",
            IsActive = true,
            IsAuthenticated = true,
        };

        // Act
        var result = await _userService.UpdateUserAsync(999999, userRequestUpdateDTO);

        // Assert
        Assert.True(result);
    }

    [Theory(DisplayName = "Metodo para excluir fisicamente, a partir do seu ID")]
    [InlineData(999999)]
    public async Task DeleteUserPhysicalAsync(long id)
    {
        // Act
        var result = await _userService.DeleteUserPhysicalAsync(id);

        // Assert
        Assert.True(result);
    }

    [Theory(DisplayName = "Metodo para excluir logicamente, a partir do seu ID")]
    [InlineData(999999)]
    public async Task DeleteUserLogicAsync(long id)
    {
        // Act
        var result = await _userService.DeleteUserLogicAsync(id);

        // Assert
        Assert.True(result);
    }

    [Theory(DisplayName = "Metodo para verificar a possibilidade de exclusão, a partir do seu ID")]
    [InlineData(999999)]
    public async Task CanDeleteUserByIdAsync(long id)
    {
        // Act
        var result = await _userService.CanDeleteUserByIdAsync(id);

        // Assert
        Assert.True(result);
    }

    [Theory(DisplayName = "Metodo para mudar o status de Ativo ou Inativo, a partir do seu ID")]
    [InlineData(999999)]
    public async Task UpdateStatusById(long id)
    {
        // Act
        var result = await _userService.ReactiveUserByIdAsync(id);

        // Assert
        Assert.True(result);
    }

    [Theory(DisplayName = "Metodo para verificar se existe o registro do ID informado")]
    [InlineData(999999)]
    public async Task ExistById(long id)
    {
        // Act
        var result = await _userService.ExistUserByIdAsync(id);

        // Assert
        Assert.True(result);
    }

    [Theory(DisplayName = "Metodo para verificar se existe o registro do Login informado")]
    [InlineData("XPTO")]
    public async Task ExistByLogin(string login)
    {
        // Act
        var result = await _userService.ExistUserByLoginAsync(login);

        // Assert
        Assert.True(result);
    }

    [Theory(DisplayName = "Metodo para buscar, a partir do seu ID")]
    [InlineData(999999)]
    public async Task GetById(long id)
    {
        // Act
        var result = await _userService.GetUserByIdAsync(id);

        // Assert
        Assert.NotNull(result);
    }

    [Fact(DisplayName = "Metodo para buscar uma lista de registros, a partir do filtro")]
    public async Task GetAllUserAsync()
    {
        // Act
        IEnumerable<UserResponseDTO> result = await _userService.GetAllUserAsync();

        // Assert
        Assert.Equal(1, result.Count());
    }

    [Fact(DisplayName = "Metodo para buscar uma lista de registros paginada, a partir do filtro")]
    public async Task GetAllUserPaginateAsync()
    {
        // Arrange 
        UserPaginateFilter userFilter = new UserPaginateFilter
        {
            IsActive = true,
            PageIndex = 0,
            PageSize = 10,
        };

        // Act
        BasePagedResultModel<UserResponseDTO> result = await _userService.GetAllUserPaginateAsync(userFilter);

        // Assert
        Assert.Equal(1, result.TotalRecords);
    }

    [Fact(DisplayName = "Validar os parametros do payload enviado ou objeto criado")]
    public void ValidatePayload()
    {
        // Arrange
        UserRequestCreateDTO userRequestCreateDTO = new UserRequestCreateDTO
        {
            Login = "XPTO",
            Password = "1234Mudar",
            IsActive = true,
            IsAuthenticated = true,
        };

        userRequestCreateDTO.Login.Should().NotBeNullOrWhiteSpace();
        userRequestCreateDTO.Login.Should().Be("XPTO");
        userRequestCreateDTO.Password.Should().NotBeNullOrWhiteSpace();
        userRequestCreateDTO.Password.Should().Be("1234Mudar");
        userRequestCreateDTO.IsActive.Should().Be(true);
        userRequestCreateDTO.IsAuthenticated.Should().Be(true);
    }

    [Fact(DisplayName = "Exemplo para testar uma condição de Throw exception ao criar o objeto")]
    public void GenerateThrowError()
    {
        Action act = () => new UserRequestCreateDTO();
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact(DisplayName = "Testando o metodo pela controller")]
    public async Task TestController()
    {
        // Arrange
        UserRequestCreateDTO userRequestCreateDTO = new UserRequestCreateDTO
        {
            Login = "XPTO",
            Password = "1234Mudar",
            IsActive = true,
            IsAuthenticated = true,
        };

        // Act
        _mocker.GetMock<IUserService>().Setup(p => p.CreateUserAsync(It.IsAny<UserRequestCreateDTO>())).ReturnsAsync(true);
        var userController = _mocker.CreateInstance<UsersController>();
        var result = await userController.Create(userRequestCreateDTO);

        // Assert
        result.Should().BeOfType<CreatedAtActionResult>();
    }
}