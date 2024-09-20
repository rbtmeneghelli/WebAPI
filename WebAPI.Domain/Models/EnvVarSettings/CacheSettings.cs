namespace WebAPI.Domain.Models.EnvVarSettings;

public sealed record CacheSettings
{
    public int AbsoluteExpirationInHours { get; init; }
    public int SlidingExpirationInMinutes { get; init; }
}
