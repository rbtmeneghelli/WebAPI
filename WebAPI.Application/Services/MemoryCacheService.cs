using Microsoft.Extensions.Caching.Memory;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Models.EnvVarSettings;

namespace WebAPI.Application.Services;

public class MemoryCacheService : IMemoryCacheService
{
    private readonly IMemoryCache _iMemoryCache;
    private CacheSettings _cacheSettings { get; }
    private MemoryCacheEntryOptions _cacheOptions;

    public MemoryCacheService(IMemoryCache iMemoryCache, CacheSettings cacheSettings)
    {
        _iMemoryCache = iMemoryCache;
        _cacheSettings = cacheSettings;

        if (GuardClauses.ObjectIsNotNull(_cacheSettings))
        {
            _cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(_cacheSettings.AbsoluteExpirationInHours),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(_cacheSettings.SlidingExpirationInMinutes),
                Size = 1024
            };
        }
    }

    public bool TryGet<T>(string cacheKey, out T data)
    {
        _iMemoryCache.TryGetValue(cacheKey, out data);
        return GuardClauses.ObjectIsNull(data);
    }

    public T Set<T>(string cacheKey, T value)
    {
        return _iMemoryCache.Set(cacheKey, value, _cacheOptions);
    }

    public T Get<T>(string cacheKey)
    {
        return _iMemoryCache.Get<T>(cacheKey);
    }

    public void Remove(string cacheKey)
    {
        _iMemoryCache.Remove(cacheKey);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
