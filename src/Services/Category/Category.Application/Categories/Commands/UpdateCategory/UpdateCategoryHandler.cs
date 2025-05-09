// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Category.Application.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryHandler(
    ICategoryCacheService cacheService,
    IApplicationDbContext dbContext,
    ILogger<UpdateCategoryHandler> logger) : ICommandHandler<UpdateCategoryCommand>
{
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var targetCategory = await dbContext.Categories.FirstOrDefaultAsync(category =>
            (category.Id == request.Category.Id)
            && (category.ParentId == request.Category.ParentId));

        logger.LogInformation("UpdateCategoryHandler: {CategoryId}", JsonConvert.SerializeObject(targetCategory));
        if (targetCategory is null) throw new Exception("Category not found");

        targetCategory.Update(
            name: request.Category.Name,
            avatar: request.Category.Avatar,
            description: request.Category.Description,
            priority: request.Category.Priority,
            validFlg: request.Category.ValidFlg,
            lastModified: DateTime.UtcNow,
            lastModifiedBy: request.Category.LastModifiedBy);

        await dbContext.SaveChangesAsync(cancellationToken);
        await cacheService.RefreshCache();

        return Unit.Value;
    }
}