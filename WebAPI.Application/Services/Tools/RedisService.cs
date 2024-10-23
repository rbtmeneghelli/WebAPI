using WebAPI.Domain.ExtensionMethods;
using Microsoft.Extensions.Caching.Distributed;
using WebAPI.Application.Generic;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Tools;

public sealed class RedisService : GenericService, IRedisService
{
    private readonly IDistributedCache _iDistributedCache;

    public RedisService(IDistributedCache iDistributedCache, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iDistributedCache = iDistributedCache;
    }

    private DistributedCacheEntryOptions SetTimeToExpire()
    {
        DistributedCacheEntryOptions cacheEntryOptions = new DistributedCacheEntryOptions();
        cacheEntryOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(60));
        return cacheEntryOptions;
    }

    public async Task AddDataStringAsync(string redisKey, string redisData)
    {
        await _iDistributedCache.SetStringAsync(redisKey, redisData, SetTimeToExpire());
    }

    public async Task<string> GetDataStringAsync(string redisKey)
    {
        var result = await _iDistributedCache.GetStringAsync(redisKey);
        return result;
    }

    public async Task AddDataObjectAsync<T>(string redisKey, T redisData) where T : class
    {
        await _iDistributedCache.SetStringAsync(redisKey, redisData.SerializeObject(), SetTimeToExpire());
    }

    public async Task<T> GetDataObjectAsync<T>(string redisKey) where T : class
    {
        var result = await _iDistributedCache.GetStringAsync(redisKey);
        return result.DeserializeObject<T>();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
