// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Category.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(string CategoryId) : IQuery<GetCategoryByIdResult>;

public record GetCategoryByIdResult(CategoryItem? category);
