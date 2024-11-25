using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebAPI.InfraStructure.Data.Context;

namespace WebAPI.Infrastructure.CrossCutting.BackgroundServices;

public class FreshContextInstanceBackgroundService : BackgroundService
{
    private readonly IDbContextFactory<WebAPIContext> _dbContextFactory;

    public FreshContextInstanceBackgroundService(IDbContextFactory<WebAPIContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync(stoppingToken))
            {

            }

            await Task.Delay(1000, stoppingToken); // Atraso de 1 segundo
        }
    }
}
