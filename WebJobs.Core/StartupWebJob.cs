using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAPI.InfraStructure.IoC.Containers;

namespace WebJobs.Core
{
    public class StartupWebJob
    {
        /// <summary>
        /// Ao criar um novo Job, criar a variavel de ambiente na maquina e no azure
        /// Formato >> AzureWebJobs.{{NOME_FUNCTION_NAME}}.Disabled
        /// Exemplo >> AzureWebJobs.DefaultWebAPIJob.Disabled
        /// Valor >> 0 (Irá executar), 1 (Não irá executar)
        /// </summary>
        /// <param name="args"></param>
        public static void Start(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var host = new HostBuilder()
                .ConfigureWebJobs(builder =>
                {
                    ContainerService.RegisterServices(builder.Services);
                    builder.AddAzureStorageBlobs();
                    builder.AddTimers();
                    builder.AddHttp();

                    #region Get Dependency Injection to user

                    //ServiceCollection services = new ServiceCollection();
                    ////services.AddMvc(); // Exemplo
                    //ServiceProvider serviceProvider = services.BuildServiceProvider();
                    //var startupWebJob = serviceProvider.GetService<ILogger<StartupWebJob>>();

                    #endregion
                })
                .ConfigureLogging((context, ctx) =>
                {
                    ctx.AddConsole();
                })
                .ConfigureServices(services =>
                {
                    services.AddLogging();
                })
                .Build();

            host.Run();
        }
    }
}