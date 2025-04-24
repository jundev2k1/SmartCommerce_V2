// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Category.Application.Categories.Queries.GetCategoryIncludeChildren;

public record GetCategoryIncludeChildrenQuery(string CategoryId) : IQuery<GetCategoryIncludeChildrenResult>;

public record GetCategoryIncludeChildrenResult(CategoryItem? Category, IEnumerable<CategoryItem> Children);
