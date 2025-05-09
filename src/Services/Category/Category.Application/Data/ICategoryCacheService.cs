// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Category.Application.Data;

public interface ICategoryCacheService
{
    Task RefreshCache();
    Task<CategoryItem[]> GetAllCategoriesAsync();
}
