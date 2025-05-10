// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Caches;
using Category.Application.Categories.Dtos;
using Category.Application.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Category.Infrastructure.Data.Caching;

public sealed class CategoryCacheService(
    IRedisCacheService redisCache,
    IApplicationDbContext dbContext) : ICategoryCacheService
{
    private const string CACHE_KEY_CATEGORY_LIST = "list";

    public async Task RefreshCache()
    {
        var categories = await dbContext.Categories
            .AsNoTracking()
            .Select(category => category.Adapt<CategoryDto>())
            .ToArrayAsync();
        await redisCache.SetAsync(CACHE_KEY_CATEGORY_LIST, categories);
    }

    public async Task<CategoryDto[]> GetAllCategoriesAsync(CancellationToken cancellation)
    {
		cancellation.ThrowIfCancellationRequested();

		var result = await redisCache.GetAsync<CategoryDto[]>(CACHE_KEY_CATEGORY_LIST);
        if (result is not null) return result;

        await RefreshCache();
        return await GetAllCategoriesAsync(cancellation);
    }
}
