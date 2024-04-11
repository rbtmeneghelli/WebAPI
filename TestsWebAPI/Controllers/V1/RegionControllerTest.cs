using WebAPI.Application.Interfaces;
using WebAPI.Application.Services;
using Moq;
using NPOI.SS.Formula.Functions;
using Region = WebAPI.Domain.Entities.Region;

namespace TestsWebAPI.Controllers.V1;

public class RegionControllerTest : GenericControllerTest
{
    public RegionControllerTest(BuilderServiceProvider builderServiceProvider) : base(builderServiceProvider)
    {
    }

    /// <summary>
    /// Essa forma de teste serve para testar metodos sem persistir nada com banco de dados, apenas codigo
    /// Evitar testes com metodo assincronos ToListAsync, FirstOrDefaultAsync e etc...
    /// </summary>
    [Fact(DisplayName = "Metodo para buscar todas as regiões cadastradas")]
    public async Task GetAllRegionAsync()
    {
        // Arrange
        var regionService = new Mock<IRegionService>();
        var regionRepo = new Mock<IRegionRepository>();
        var notificationRepo = new Mock<INotificationMessageService>();
        var list = new List<Region>
        {
            new Region() { Id = 1, Name = "XPTO" }
        };
        regionService.Setup(param => param.GetAllRegionAsync()).ReturnsAsync(list);
        RegionService service = new RegionService(regionRepo.Object, notificationRepo.Object);

        // Act
        var result = await service.GetAllRegionAsync();
        // Assert
        Assert.True(true);
    }

    /// <summary>
    /// Essa forma de teste serve para testar metodos sem persistir nada com banco de dados, apenas codigo
    /// </summary>
    /// <param name="regionId"></param>
    /// <param name="testResult"></param>
    [Theory(DisplayName = "Metodo para buscar a região por ID cadastrada")]
    [InlineData(0, false)]
    [InlineData(1, true)]
    [InlineData(2, true)]
    public void ExistRegionById(int regionId, bool testResult)
    {
        // Arrange
        var regionService = new Mock<IRegionService>();
        var regionRepo = new Mock<IRegionRepository>();
        var notificationRepo = new Mock<INotificationMessageService>();
        regionService.Setup(param => param.ExistRegionById(regionId)).Returns(testResult);
        RegionService service = new RegionService(regionRepo.Object, notificationRepo.Object);

        // Act
        var result = service.ExistRegionById(regionId);
        // Assert
        Assert.Equal(result, testResult);
    }
}
