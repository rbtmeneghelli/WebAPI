namespace WebAPI.Application.Interfaces;

public interface IMemoryCacheService : IDisposable
{
    bool TryGet<T>(string cacheKey, out T data);
    T Set<T>(string cacheKey, T data);
    T Get<T>(string cacheKey);
    void Remove(string cacheKey);
}

