using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RedisManager;

public static class CacheHelper
{
    public static async Task SetRecordAsync<T>(this IDistributedCache cache,
                                                  string recordId,
                                                  T data,
                                                  TimeSpan? absoluteExpireTime = null,
                                                  TimeSpan? slidingExpireTime = null, CancellationToken cancellationToken = default)
    {
        DistributedCacheEntryOptions options = new();

        options.AbsoluteExpirationRelativeToNow = absoluteExpireTime;
        options.SlidingExpiration = slidingExpireTime;
        string jsonData = string.Empty;

        if (typeof(T) == typeof(string))
        {
            jsonData = data.ToString();
        }
        else
        {
            jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles });
        }
        await cache.SetStringAsync(recordId, jsonData, options, cancellationToken);
    }

    public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache,
                                                   string recordId, CancellationToken cancellationToken = default)
    {
        var jsonData = await cache.GetStringAsync(recordId, cancellationToken);
        if (jsonData is null)

        {
            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
            {

                return (T)Activator.CreateInstance(typeof(T));
            }

            return default(T);
        }

        if (typeof(T) == typeof(string))
        {
            return (T)(object)jsonData;
        }
        var t = JsonSerializer.Deserialize<T>(jsonData);
        return JsonSerializer.Deserialize<T>(jsonData);
    }

    public static async Task RemoveRecordAsync(this IDistributedCache cache,
                                               string recordId, CancellationToken cancellationToken = default)
    {
        await cache.RemoveAsync(recordId, cancellationToken);

        _ = Task.CompletedTask;
    }

    public static async Task RemoveRecordAsync(this IDistributedCache cache,
                                           List<string> recordIds, CancellationToken cancellationToken = default)
    {
        if (recordIds is not null && recordIds.Any())
        {
            foreach (var recordId in recordIds)
            {
                await cache.RemoveAsync(recordId, cancellationToken);
            }
        }

        _ = Task.CompletedTask;
    }

    public static Task<Dictionary<string, string>>? GetRecordByPatternAsync(this IConnectionMultiplexer connectionMultiplexer, string pattern)
    {
        try
        {
            bool notFound = false;
            Dictionary<string, string> keys = new();

            var endPoints = connectionMultiplexer.GetEndPoints();

            if (endPoints is not null && endPoints.Any())
            {
                foreach (var endPoint in endPoints)
                {
                    if (notFound)
                    {
                        break;
                    }

                    if (!keys.Any())
                    {
                        var server = connectionMultiplexer.GetServer(endPoint);

                        if (server.IsConnected)
                        {
                            foreach (var item in server.Keys(pattern: pattern))
                            {
                                if (!keys.ContainsKey(item))
                                {
                                    keys.Add(item, item);
                                }
                            }

                            if (!keys.Any())
                            {
                                notFound = true;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }

            return Task.FromResult(keys);
        }

        catch (Exception)
        {
            return null;
        }

    }
}
