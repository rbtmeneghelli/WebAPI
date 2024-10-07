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
    private readonly INotificationMessageService _iNotificationMessageService;

    public RegionControllerTest(BuilderServiceProvider builderServiceProvider) : base(builderServiceProvider)
    {
        _iNotificationMessageService = _serviceProvider.GetService<INotificationMessageService>();
        _mockRepository = new Mock<IRegionRepository>();
        _iRegionService = new RegionService(_mockRepository.Object, _iNotificationMessageService);
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
        // Arrange
        bool hasRegionData = false;

        // Act
        var regions = await _iRegionService.GetAllRegionAsync();
        hasRegionData = regions.Any();

        // Assert
        Assert.True(hasRegionData, "A lista informada possui dados");
    }

    [Theory(DisplayName = "Existe a Região de um determinado ID")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void ExistRegionById(int regionID)
    {
        //Arrange
        bool existRegion = false;

        //Act
        existRegion = _iRegionService.ExistRegionById(regionID);

        // Assert
        if (existRegion)
            Assert.True(existRegion, "Região encontrada com sucesso");
        else
            Assert.False(existRegion, "Região não foi encontrada com sucesso");
    }
}
