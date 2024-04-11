namespace WebAPI.Domain.Models;

public record CacheConfiguration
{
    public int AbsoluteExpirationInHours { get; set; }
    public int SlidingExpirationInMinutes { get; set; }
}
