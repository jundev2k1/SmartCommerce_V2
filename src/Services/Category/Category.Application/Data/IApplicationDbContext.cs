// Copyright (c) 2025 - Jun Dev. All rights reserved

using Microsoft.EntityFrameworkCore;

namespace Category.Application.Data;

public interface IApplicationDbContext
{
    DbSet<CategoryItem> Categories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
