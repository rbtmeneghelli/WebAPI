using Moq;
using NUnit.Framework;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Interfaces.Generic;
using Assert = NUnit.Framework.Assert;

namespace TestsWebAPI.Controllers.V1;

// Exemplo de teste unitario com NUnit (Verificar se a injeção de dependencia funciona ou se precisa do BuilderService)
[TestFixture]
public sealed class NUnitControllerTest : GenericControllerTest
{
    private Mock<IGenericReadRepository<Employee>> _mockDataRepository;

    public NUnitControllerTest(BuilderServiceProvider builderServiceProvider) : base(builderServiceProvider)
    {        
    }
    
    [SetUp]
    public void SetUp()
    {
        _mockDataRepository = new Mock<IGenericReadRepository<Employee>>();
    }

    [TestCase("", "73990324000199")]
    [TestCase("", "73990324000199")]
    public void GetAllData_ShouldReturnPagedListResponse_WhenDataExist(string name, string cpfCnpj)
    {
        // Arrange
        var dataList = new List<Employee>
        {
            new Employee { Id = 1, Name = "Employee 1" },
            new Employee { Id = 2, Name = "Employee 2" },
            new Employee { Id = 3, Name = "Employee 3" },
            new Employee { Id = 4, Name = "Employee 4" }
        };

        // Act
        _mockDataRepository.Setup(repo => repo.GetAll(false)).Returns(dataList.AsQueryable());

        var mockResult = _mockDataRepository.Object.GetAll(false);

        // Assert
        Assert.That(mockResult.Count, Is.EqualTo(4));
    }
}


