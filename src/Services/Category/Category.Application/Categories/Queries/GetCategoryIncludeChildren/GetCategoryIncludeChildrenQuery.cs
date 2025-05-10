// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Categories.Dtos;

namespace Category.Application.Categories.Queries.GetCategoryIncludeChildren;

public record GetCategoryIncludeChildrenQuery(string CategoryId) : IQuery<GetCategoryIncludeChildrenResult>;

public record GetCategoryIncludeChildrenResult(IEnumerable<CategoryDto> Items);
