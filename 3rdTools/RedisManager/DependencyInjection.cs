using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace RedisManager;

public static class DependencyInjection
{
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            configuration.GetSection("Redis").Bind(options);
        });

        services.AddSingleton<IConnectionMultiplexer>(sp =>
        ConnectionMultiplexer.Connect(configuration.GetSection("Redis")["Configuration"])
        );

        return services;
    }
}
