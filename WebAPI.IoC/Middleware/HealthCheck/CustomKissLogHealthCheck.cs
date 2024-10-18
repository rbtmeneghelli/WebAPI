using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebAPI.Domain;

namespace WebAPI.IoC.Middleware.HealthCheck;

public class CustomKissLogHealthCheck : IHealthCheck
{
    private readonly IHttpClientFactory _iHttpClientFactory;
    private EnvironmentVariables _environmentVariables { get; }

    public CustomKissLogHealthCheck(IHttpClientFactory iHttpClientFactory, EnvironmentVariables environmentVariables)
    {
        _iHttpClientFactory = iHttpClientFactory;
        _environmentVariables = environmentVariables;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        using (var httpClient = _iHttpClientFactory.CreateClient())
        {
            var response = await httpClient.GetAsync("https://api.ipify.org");

            if (response.IsSuccessStatusCode)
            {
                return HealthCheckResult.Healthy($"Remote endpoints is healthy.");
            }

            return HealthCheckResult.Unhealthy("Remote endpoint is unhealthy");
        }
    }
}
