namespace News.Application.Interfaces;

public interface IRedisService
{
    Task SetAsync<T>(string key, T value, TimeSpan? expire = null);
    Task<T?> GetAsync<T>(string key);
}