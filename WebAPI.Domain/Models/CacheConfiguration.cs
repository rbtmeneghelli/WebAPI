namespace WebAPI.Domain.Models;

public sealed record CacheSettings
{
    public int AbsoluteExpirationInHours { get; init; }
    public int SlidingExpirationInMinutes { get; init; }
}
