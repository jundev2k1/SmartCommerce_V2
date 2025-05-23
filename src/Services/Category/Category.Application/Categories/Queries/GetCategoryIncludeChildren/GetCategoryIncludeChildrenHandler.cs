﻿// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Data;
using Grpc.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Category.Application.Categories.Queries.GetCategoryIncludeChildren;

public sealed class GetCategoryIncludeChildrenHandler(
    ICategoryCacheService cacheService,
    ILogger<GetCategoryIncludeChildrenHandler> logger)
    : IQueryHandler<GetCategoryIncludeChildrenQuery, GetCategoryIncludeChildrenResult>
{
    public async Task<GetCategoryIncludeChildrenResult> Handle(GetCategoryIncludeChildrenQuery query, CancellationToken cancellation)
    {
        var categoryList = await cacheService.GetAllCategoriesAsync(cancellation);
        logger.LogInformation("GetCategoryIncludeChildrenHandler: {CategoryList}", query.CategoryId);
        logger.LogInformation(JsonConvert.SerializeObject(categoryList));
        var result = categoryList
            .Where(cate => cate.Id.StartsWith(query.CategoryId))
            .OrderBy(cate => cate.Id.Length)
            .ThenBy(cate => cate.Id)
            .ToArray();
        return new GetCategoryIncludeChildrenResult(result);
    }
}
