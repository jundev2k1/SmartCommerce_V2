// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Category.Application.Categories.Queries.GetCategoryById;

public sealed class GetCategoryByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCategoryByIdQuery, GetCategoryByIdResult>
{
    public async Task<GetCategoryByIdResult> Handle(GetCategoryByIdQuery query, CancellationToken cancellation)
    {
        var category = await dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == CategoryId.Of(query.CategoryId), cancellation);
        return new GetCategoryByIdResult(category);
    }
}
