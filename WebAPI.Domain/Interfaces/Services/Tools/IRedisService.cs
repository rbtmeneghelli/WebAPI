namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface IRedisService : IDisposable
{
    Task AddDataStringAsync(string redisKey, string redisData);
    Task<string> GetDataStringAsync(string redisKey);
    Task AddDataObjectAsync<T>(string redisKey, T redisData) where T : class;
    Task<T> GetDataObjectAsync<T>(string redisKey) where T : class;
}
