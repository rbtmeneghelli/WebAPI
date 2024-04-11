using WebAPI.Domain.ExtensionMethods;
using Microsoft.Extensions.Caching.Distributed;

namespace WebAPI.Application.Services;

public sealed class RedisService : IRedisService
{
    private readonly IDistributedCache _cache;

    public RedisService(IDistributedCache cache)
    {
        _cache = cache;
    }

    private DistributedCacheEntryOptions SetTimeToExpire()
    {
        DistributedCacheEntryOptions cacheEntryOptions = new DistributedCacheEntryOptions();
        cacheEntryOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(60));
        return cacheEntryOptions;
    }

    public async Task AddDataStringAsync(string redisKey, string redisData)
    {
        await _cache.SetStringAsync(redisKey, redisData, SetTimeToExpire());
    }

    public async Task<string> GetDataStringAsync(string redisKey)
    {
        var result = await _cache.GetStringAsync(redisKey);
        return result;
    }

    public async Task AddDataObjectAsync<T>(string redisKey, T redisData) where T : class
    {
        await _cache.SetStringAsync(redisKey, redisData.SerializeObject(), SetTimeToExpire());
    }

    public async Task<T> GetDataObjectAsync<T>(string redisKey) where T : class
    {
        var result = await _cache.GetStringAsync(redisKey);
        return result.DeserializeObject<T>();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
