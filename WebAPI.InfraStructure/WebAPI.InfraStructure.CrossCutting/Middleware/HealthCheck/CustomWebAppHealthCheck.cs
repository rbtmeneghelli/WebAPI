using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebAPI.Infrastructure.CrossCutting.Middleware.HealthCheck;

public class CustomWebAppHealthCheck : IHealthCheck
{
    private readonly IHttpClientFactory _iHttpClientFactory;

    public CustomWebAppHealthCheck(IHttpClientFactory iHttpClientFactory)
    {
        _iHttpClientFactory = iHttpClientFactory;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        using (var httpClient = _iHttpClientFactory.CreateClient())
        {
            var response = await httpClient.GetAsync("https://localhost:8999");

            if (response.IsSuccessStatusCode)
            {
                return HealthCheckResult.Healthy("Aplicação Web está em execução");
            }

            return HealthCheckResult.Unhealthy("Aplicação Web não está em execução");
        }
    }
}
