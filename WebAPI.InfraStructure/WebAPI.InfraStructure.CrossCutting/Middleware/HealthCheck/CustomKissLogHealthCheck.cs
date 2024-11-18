using KissLog;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebAPI.Infrastructure.CrossCutting.Middleware.HealthCheck;

public class CustomKissLogHealthCheck : IHealthCheck
{
    private readonly IKLogger _iKLogger;

    public CustomKissLogHealthCheck(IKLogger iKLogger)
    {
        _iKLogger = iKLogger;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            _iKLogger.Info("Testing KissLog connectivity");
            return HealthCheckResult.Healthy("KissLog is online.");
        }
        catch (Exception ex)
        {
            _iKLogger.Error("KissLog is offline: " + ex.Message);
            return HealthCheckResult.Unhealthy("KissLog is offline.");
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}

