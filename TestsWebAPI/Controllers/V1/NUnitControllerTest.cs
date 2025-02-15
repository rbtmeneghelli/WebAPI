namespace TestsWebAPI.Controllers.V1;

// Exemplo de teste unitario com NUnit (Verificar se a injeção de dependencia funciona ou se precisa do BuilderService)
[TestFixture]
public sealed class NUnitControllerTest : GenericControllerTest
{
    private Mock<IDataRepository> _mockDataRepository;

    public NUnitControllerTest(BuilderServiceProvider builderServiceProvider) : base(builderServiceProvider)
    {        
    }
    
    [SetUp]
    public void SetUp()
    {
        _mockDataRepository = new Mock<IDataRepository>();
    }

    [TestCase("", "73990324000199")]
    [TestCase("", "73990324000199")]
    public async Task GetAllData_ShouldReturnPagedListResponse_WhenTakersExist(string name, string cpfCnpj)
    {
        // Arrange
        var dataList = new List<Data>
        {
            new Data { Id = 1, Name = "Data 1",  Enabled = true,  CpfCnpj = "19013280072" },
            new Data { Id = 2, Name = "Data 2",  Enabled = false, CpfCnpj = "29399711021" },
            new Data { Id = 3, Name = "Data 3",  Enabled = false, CpfCnpj = "63383005000160" },
            new Data { Id = 4, Name = "Data 4",  Enabled = false, CpfCnpj = "73990324000198" }
        };

        // Act
        _mockDataRepository.Setup(repo => repo.GetAllData(null, null, 0, int.MaxValue)).ReturnsAsync(dataList);

        var mockResult = await _mockDataRepository.Object.GetAllData(null, null, 0, int.MaxValue);

        // Assert
        Assert.That(mockResult.Count, Is.EqualTo(4));
    }
}


