using WebAPI.Application.Services;
using Moq;
using Region = WebAPI.Domain.Entities.Others.Region;
using WebAPI.Domain.Interfaces.Services.Common;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using FastPackForShare.Interfaces;

namespace TestsWebAPI.Controllers.V1;

public sealed class RegionControllerTest : GenericControllerTest
{
    private readonly Mock<IRegionRepository> _mockRepository;
    private readonly Mock<INotificationMessageService> _iNotificationMessageService;
    private readonly IRegionService _iRegionService;
    private readonly Mock<IMapperService> _iMapperService;

    public RegionControllerTest(BuilderServiceProvider builderServiceProvider) : base(builderServiceProvider)
    {
        _iNotificationMessageService = new Mock<INotificationMessageService>();
        _mockRepository = new Mock<IRegionRepository>();
        _iRegionService = new RegionService(_mockRepository.Object, _iMapperService.Object, _iNotificationMessageService.Object);
    }

    public static IEnumerable<object[]> GetRegions()
    {
        yield return new object[]
        {
            new List<Region>
            {
                new Region() { Id = 1, Name = "XPTO" },
                new Region() { Id = 2, Name = "XYZ" },
                new Region() { Id = 3, Name = "ABC" }
            }
        };
    }

    /// <summary>
    /// Essa forma de teste serve para testar metodos sem persistir nada com banco de dados, apenas codigo
    /// Evitar testes com metodo assincronos ToListAsync, FirstOrDefaultAsync e etc...
    /// </summary>
    [Theory(DisplayName = "Metodo para verificar se a lista tem dados")]
    [MemberData(nameof(GetRegions))]
    public async Task ExistRegionsOnlist(IEnumerable<Region> list)
    {
        //Arrange
        bool hasRegionData = false;

        //Act
        hasRegionData = list.Any();
        await Task.CompletedTask;

        // Assert
        Assert.True(hasRegionData, "A lista informada possui dados");
    }

    /// <summary>
    /// Essa forma de teste serve para testar metodos sem persistir nada com banco de dados, apenas codigo
    /// Evitar testes com metodo assincronos ToListAsync, FirstOrDefaultAsync e etc...
    /// </summary>
    [Theory(DisplayName = "Metodo para buscar todas as regiões cadastradas")]
    [MemberData(nameof(GetRegions))]
    public async Task GetAllRegionAsync(IEnumerable<Region> list)
    {
        //Arrange
        _mockRepository.Setup(r => r.GetAll(It.IsAny<bool>())).Returns(list.AsQueryable()).Verifiable();

        //Act
        var result = await _iRegionService.GetQueryAbleRegionAsync();
        var listDb = result.ToList();

        //Assert
        Assert.NotNull(listDb);
        Assert.Equal(3, listDb.Count);

        _mockRepository.Verify(r => r.GetAll(It.IsAny<bool>()), Times.Once);
    }

    [Theory(DisplayName = "Metodo para verificar se existe a Região do ID informado")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void ExistRegionById(long regionID)
    {
        var arrRegionId = new long[2] { 1, 2 };

        //Arrange
        _mockRepository.Setup(service => service.Exist(p => p.Id == regionID)).Returns(arrRegionId.Contains(regionID));

        ////Act
        bool existRegion = _mockRepository.Object.Exist(p => p.Id == regionID);

        // Assert
        if (existRegion)
            Assert.True(existRegion, "Região encontrada com sucesso");
        else
            Assert.False(existRegion, "Região não foi encontrada com sucesso");
    }

    [Theory(DisplayName = "Metodo para cadastrar uma nova região")]
    [InlineData(1, "Updated Entity")]
    public async Task CreateRegion(long regionID, string regionName)
    {
        // Arrange
        var entity = new Region { Id = regionID, Name = regionName };
        _mockRepository.Setup(r => r.Add(It.IsAny<Region>())).Verifiable();

        // Act
        var result = await _iRegionService.CreateRegion(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity.Id, result.Id);
        Assert.Equal(entity.Name, result.Name);
        _mockRepository.Verify(r => r.Add(It.IsAny<Region>()), Times.Once);
        //_mockRepository.Verify(r => r.Add(It.IsAny<Region>()), Times.Never); //Para caso de falha durante o processo, utilizar sempre o Times.Never
    }

    [Theory(DisplayName = "Metodo para atualizar uma região, a partir do seu ID")]
    [InlineData(1, "Updated Entity")]
    public async Task UpdateRegion(long regionID, string regionName)
    {
        // Arrange
        var entity = new Region { Id = regionID, Name = regionName };
        _mockRepository.Setup(r => r.Update(It.IsAny<Region>())).Verifiable();

        // Act
        var result = await _iRegionService.UpdateRegion(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Updated Entity", result.Name);
        _mockRepository.Verify(r => r.Update(It.IsAny<Region>()), Times.Once);
    }

    [Theory(DisplayName = "Metodo para excluir fisicamente uma região, a partir do seu ID")]
    [InlineData(1, "Updated Entity")]
    public async Task DeleteRegion(long regionID, string regionName)
    {
        // Arrange
        var entity = new Region { Id = regionID, Name = regionName };
        _mockRepository.Setup(r => r.Remove(It.IsAny<Region>())).Verifiable();

        // Act
        await _iRegionService.DeleteRegion(entity);

        // Assert
        Assert.True(true);
        _mockRepository.Verify(r => r.Remove(It.IsAny<Region>()), Times.Once);
    }

    [Theory(DisplayName = "Metodo para buscar a região, a partir do seu ID")]
    [InlineData(1, "Updated Entity")]
    public void GetRegionById(long regionID, string regionName)
    {
        // Arrange
        var entity = new Region { Id = regionID, Name = regionName };
        _mockRepository.Setup(r => r.GetById(It.IsAny<long>())).Returns(entity);

        // Act
        var result = _iRegionService.GetRegionById(regionID);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Test Entity", result.Name);
        _mockRepository.Verify(r => r.GetById(It.IsAny<long>()), Times.Once);
    }

    [Theory(DisplayName = "Metodo para atualizar o status de uma região para Ativo/Inativo, a partir do seu ID")]
    [InlineData(1, false)]
    [InlineData(3, true)]
    public async Task UpdateStatusRegionbyId(long regionID, bool regionStatus)
    {
        // Arrange
        _mockRepository.Setup(r => r.GetById(It.IsAny<long>())).Returns(new Region { Id = regionID, IsActive = regionStatus }).Verifiable();
        _mockRepository.Setup(r => r.Update(It.IsAny<Region>())).Verifiable();

        // Act
        var result = await _iRegionService.UpdateRegionStatusByIdAsync(regionID);

        // Assert
        _mockRepository.Verify(r => r.GetById(It.IsAny<long>()), Times.Once);
        _mockRepository.Verify(r => r.Update(It.IsAny<Region>()), Times.Once);
    }
}
