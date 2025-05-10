// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Categories.Dtos;

namespace Category.Application.Data;

public interface ICategoryCacheService
{
    Task RefreshCache();
    Task<CategoryDto[]> GetAllCategoriesAsync(CancellationToken cancellation);
}
