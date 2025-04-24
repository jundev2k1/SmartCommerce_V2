// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Category.Application.Categories.Queries.GetCategoryIncludeChildren;

public sealed class GetCategoryIncludeChildrenHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCategoryIncludeChildrenQuery, GetCategoryIncludeChildrenResult>
{
    public async Task<GetCategoryIncludeChildrenResult> Handle(GetCategoryIncludeChildrenQuery query, CancellationToken cancellation)
    {
        var categoryList = await dbContext.Categories.ToArrayAsync(cancellation);

        var result = categoryList
            .Where(cate => cate.Id.Value.StartsWith(query.CategoryId))
            .ToArray();
        return new GetCategoryIncludeChildrenResult(result);
    }
}
