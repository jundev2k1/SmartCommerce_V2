// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Data;

namespace Category.Application.Categories.Commands.CreateCategory;

public sealed class CreateCategoryHandler(IApplicationDbContext dbContext, ICategoryCacheService categoryCache)
    : ICommandHandler<CreateCategoryCommand, CreateCategoryResult>
{
    public async Task<CreateCategoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        dbContext.Categories.Add(request.Category);
        await dbContext.SaveChangesAsync(cancellationToken);
        await categoryCache.RefreshCache();

        return new CreateCategoryResult(request.Category.Id.Value);
    }
}