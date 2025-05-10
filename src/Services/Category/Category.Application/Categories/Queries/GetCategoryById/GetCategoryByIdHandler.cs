// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Data;

namespace Category.Application.Categories.Queries.GetCategoryById;

public sealed class GetCategoryByIdHandler(ICategoryCacheService cacheService)
    : IQueryHandler<GetCategoryByIdQuery, GetCategoryByIdResult>
{
    public async Task<GetCategoryByIdResult> Handle(GetCategoryByIdQuery query, CancellationToken cancellation)
    {
        var categories = await cacheService.GetAllCategoriesAsync(cancellation);

		var category = categories.FirstOrDefault(c => c.Id == query.CategoryId);
        return new GetCategoryByIdResult(category);
    }
}
