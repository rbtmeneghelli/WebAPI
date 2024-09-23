namespace TestsWebAPI.Configuration;

public class BuilderServiceProvider
{
    public ServiceProvider ServiceProvider { get; private set; }

    public BuilderServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddHttpClient();
        serviceCollection.AddDbContext<WebAPITestContext>(opt => opt.UseInMemoryDatabase("DefaultMemoryAPI"));
        //serviceCollection.AddDbContext<DefaultWebAPITestContext>(opts => opts.UseSqlServer(defaultConnection, b => b.MinBatchSize(5).MaxBatchSize(50).MigrationsAssembly(typeof(DefaultWebAPITestContext).Assembly.FullName)));
        //serviceCollection.AddScoped<WebAPITestContext>();
        serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositoryTest<>));
        serviceCollection.AddScoped<IAuthenticateEntityRepositoryTest, AuthenticateEntityRepositoryTest>();
        serviceCollection.AddScoped<IAuthenticateEntityServiceTest, AuthenticateEntityServiceTest>();
        serviceCollection.AddScoped<IGeneralServiceTest, GeneralServiceTest>();
        ServiceProvider = serviceCollection.BuildServiceProvider();
        var context = ServiceProvider.GetRequiredService<WebAPITestContext>();
        context.Database.EnsureCreated();
    }
}