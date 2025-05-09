// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Caches;
using Category.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Category.Infrastructure.Data.Caching;

public sealed class CategoryCacheService(
    IRedisCacheService redisCache,
    IApplicationDbContext dbContext) : ICategoryCacheService
{
    private const string CACHE_KEY_CATEGORY_LIST = "category:list";

    public async Task RefreshCache()
    {
        var categories = await dbContext.Categories
            .AsNoTracking()
            .ToArrayAsync();
        await redisCache.SetAsync(CACHE_KEY_CATEGORY_LIST, categories);
    }

    public async Task<CategoryItem[]> GetAllCategoriesAsync()
    {
        var result = await redisCache.GetAsync<CategoryItem[]>(CACHE_KEY_CATEGORY_LIST);
        if (result is not null) return result;

        await RefreshCache();
        return await GetAllCategoriesAsync();
    }
}
