using Microsoft.Extensions.Caching.Memory;

namespace WebAPI.Application.Services;

public class MemoryCacheService : IMemoryCacheService
{
    private readonly IMemoryCache _memoryCache;
    private CacheSettings _cacheSettings { get; }
    private MemoryCacheEntryOptions _cacheOptions;

    public MemoryCacheService(IMemoryCache memoryCache, CacheSettings cacheSettings)
    {
        _memoryCache = memoryCache;
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
