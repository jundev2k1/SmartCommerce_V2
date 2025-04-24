// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Category.Application.Categories.Queries.GetCategoryIncludeChildren;

public sealed class GetCategoryIncludeChildrenHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCategoryIncludeChildrenQuery, GetCategoryIncludeChildrenResult>
{
    public async Task<GetCategoryIncludeChildrenResult> Handle(GetCategoryIncludeChildrenQuery query, CancellationToken cancellation)
    {
        var result = await dbContext.Categories
            .Where(cate => cate.Id.Value.StartsWith(query.CategoryId))
            .ToArrayAsync(cancellation);
        return new GetCategoryIncludeChildrenResult(result);
    }
}
