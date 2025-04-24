// Copyright (c) 2025 - Jun Dev. All rights reserved

using Microsoft.EntityFrameworkCore;

namespace Brand.Application.Data;

public interface IApplicationDbContext
{
    DbSet<BrandItem> Brands { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
