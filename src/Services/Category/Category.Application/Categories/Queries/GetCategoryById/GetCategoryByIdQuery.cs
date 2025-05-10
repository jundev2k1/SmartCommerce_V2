// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Categories.Dtos;

namespace Category.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(string CategoryId) : IQuery<GetCategoryByIdResult>;

public record GetCategoryByIdResult(CategoryDto? Category);
