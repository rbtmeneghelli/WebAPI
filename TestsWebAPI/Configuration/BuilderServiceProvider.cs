using FastPackForShare.Interfaces;
using FastPackForShare.Services;
using WebAPI.Application.Services;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.InfraStructure.Data.Repositories.Others;

namespace TestsWebAPI.Configuration;

public class BuilderServiceProvider
{
    public ServiceProvider ServiceProvider { get; private set; }

    public BuilderServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddHttpClient();
        serviceCollection.AddDbContext<WebAPITestContext>(opt => opt.UseInMemoryDatabase("WebMemoryAPI"));
        serviceCollection
        .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositoryTest<>))
        .AddScoped<IAuthenticateEntityRepositoryTest, AuthenticateEntityRepositoryTest>()
        .AddScoped<IAuthenticateEntityServiceTest, AuthenticateEntityServiceTest>()
        .AddScoped<IGeneralServiceTest, GeneralServiceTest>()
        .AddScoped<INotificationMessageService, NotificationMessageService>()
        .AddScoped<IRegionService, RegionService>()
        .AddScoped<IRegionRepository, RegionRepository>();
        ServiceProvider = serviceCollection.BuildServiceProvider();
        var context = ServiceProvider.GetRequiredService<WebAPITestContext>();
        context.Database.EnsureCreated();
    }
}