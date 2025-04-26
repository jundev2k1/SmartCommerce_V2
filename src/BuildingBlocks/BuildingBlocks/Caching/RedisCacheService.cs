// Copyright (c) 2025 - Jun Dev. All rights reserved

using System.Text.Json;
using BuildingBlocks.Caches;
using Microsoft.Extensions.Caching.Distributed;

namespace BuildingBlocks.Caching;

public class RedisCacheService(IDistributedCache distributedCache) : IRedisCacheService
{
    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var value = await distributedCache.GetStringAsync(key, cancellationToken);
        return value is null ? default : JsonSerializer.Deserialize<T>(value);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expirationTime = null, CancellationToken cancellationToken = default)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expirationTime ?? TimeSpan.FromMinutes(5)
        };
        var jsonValue = JsonSerializer.Serialize(value);
        await distributedCache.SetStringAsync(key, jsonValue, options, cancellationToken);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await distributedCache.RemoveAsync(key, cancellationToken);
    }
}
