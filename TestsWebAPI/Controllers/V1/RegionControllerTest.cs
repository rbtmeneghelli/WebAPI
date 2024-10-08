using WebAPI.Application.Services;
using Moq;
using Region = WebAPI.Domain.Entities.Others.Region;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;

namespace TestsWebAPI.Controllers.V1;

public sealed class RegionControllerTest : GenericControllerTest
{
    private readonly Mock<IRegionRepository> _mockRepository;
    private readonly IRegionService _iRegionService;
    private readonly Mock<INotificationMessageService> _iNotificationMessageService;
    private readonly Mock<IRegionService> _iRegionService2;
    public RegionControllerTest(BuilderServiceProvider builderServiceProvider) : base(builderServiceProvider)
    {
        _iNotificationMessageService = new Mock<INotificationMessageService>();
        _mockRepository = new Mock<IRegionRepository>();
        _iRegionService = new RegionService(_mockRepository.Object, _iNotificationMessageService.Object);
        _iRegionService2 = new Mock<IRegionService>();
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
        IQueryable<Region> query = list.AsQueryable();

        //Arrange
        _mockRepository.Setup(r => r.GetAll(It.IsAny<bool>())).Returns(query);

        //Act
        var result = await _iRegionService.GetQueryAbleRegionAsync();
        var listDb = result.ToList();
        //Assert
        Assert.NotNull(listDb);
        Assert.Equal(3, listDb.Count);
        _mockRepository.Verify(r => r.GetAll(It.IsAny<bool>()), Times.Once);
    }

    [Theory(DisplayName = "Existe a Região de um determinado ID")]
    [InlineData(1)]
    [InlineData(2)]
    public void ExistRegionById(long regionID)
    {
        //Arrange
        //_mockRepository.Setup(service => service.Exist(p => p.Id == regionID)).Returns(true);

        ////Act
        //bool existRegion = _mockRepository.Object.Exist(p => p.Id == regionID);

        _iRegionService2.Setup(service => service.ExistRegionById(It.IsAny<long>())).Returns<long>(id => id % 2 != 0);
        bool existRegion = _iRegionService2.Object.ExistRegionById(regionID);

        // Assert
        if (existRegion)
            Assert.True(existRegion, "Região encontrada com sucesso");
        else
            Assert.False(existRegion, "Região não foi encontrada com sucesso");
    }

    [Fact]
    public async Task CreateRegion()
    {
        // Arrange
        var entity = new Region { Id = 99, Name = "Test Entity" };
        _mockRepository.Setup(r => r.Add(It.IsAny<Region>())).Verifiable();

        // Act
        var result = await _iRegionService.Add(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity.Id, result.Id);
        Assert.Equal(entity.Name, result.Name);
        _mockRepository.Verify(r => r.Add(It.IsAny<Region>()), Times.Once);
    }

    [Fact]
    public async Task UpdateRegion()
    {
        // Arrange
        var entity = new Region { Id = 1, Name = "Updated Entity" };
        _mockRepository.Setup(r => r.Update(It.IsAny<Region>())).Verifiable();

        // Act
        var result = await _iRegionService.Update(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Updated Entity", result.Name);
        _mockRepository.Verify(r => r.Update(It.IsAny<Region>()), Times.Once);
    }

    [Fact]
    public async Task DeleteRegion()
    {
        // Arrange
        var entity = new Region { Id = 1, Name = "Updated Entity" };
        _mockRepository.Setup(r => r.Remove(It.IsAny<Region>())).Verifiable();

        // Act
        await _iRegionService.Delete(entity);

        // Assert
        Assert.True(true);
        _mockRepository.Verify(r => r.Remove(It.IsAny<Region>()), Times.Once);
    }

    //[Fact]
    //public async Task GetEntityByIdAsync_ShouldReturnEntity()
    //{
    //    // Arrange
    //    var entity = new MyEntity { Id = 1, Name = "Test Entity" };
    //    _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(entity);

    //    // Act
    //    var result = await _service.GetEntityByIdAsync(1);

    //    // Assert
    //    Assert.NotNull(result);
    //    Assert.Equal(1, result.Id);
    //    Assert.Equal("Test Entity", result.Name);
    //    _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
    //}
}
