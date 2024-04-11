using Microsoft.Extensions.Caching.Memory;

namespace WebAPI.Application.Services;

public class MemoryCacheService : IMemoryCacheService
{
    private readonly IMemoryCache _memoryCache;
    private CacheConfiguration _cacheConfig { get; }
    private MemoryCacheEntryOptions _cacheOptions;

    public MemoryCacheService(IMemoryCache memoryCache, CacheConfiguration cacheConfig)
    {
        _memoryCache = memoryCache;
        _cacheConfig = cacheConfig;

        if (GuardClauses.ObjectIsNotNull(_cacheConfig))
        {
            _cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(_cacheConfig.AbsoluteExpirationInHours),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(_cacheConfig.SlidingExpirationInMinutes),
                Size = 1024
            };
        }
    }

    public bool TryGet<T>(string cacheKey, out T data)
    {
        _memoryCache.TryGetValue(cacheKey, out data);
        return GuardClauses.ObjectIsNull(data);
    }

    public T Set<T>(string cacheKey, T value)
    {
        return _memoryCache.Set(cacheKey, value, _cacheOptions);
    }

    public T Get<T>(string cacheKey)
    {
        return _memoryCache.Get<T>(cacheKey);
    }

    public void Remove(string cacheKey)
    {
        _memoryCache.Remove(cacheKey);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
