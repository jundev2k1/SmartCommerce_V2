// Copyright (c) 2025 - Jun Dev. All rights reserved

using Brand.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Brand.Application.Brands.Queries.GetBrandById;

public sealed class GetBrandByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBrandByIdQuery, GetCategoryByIdResult>
{
    public async Task<GetCategoryByIdResult> Handle(GetBrandByIdQuery query, CancellationToken cancellation)
    {
        var category = await dbContext.Brands
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == BrandId.Of(query.BrandId), cancellation);
        return new GetCategoryByIdResult(category);
    }
}
