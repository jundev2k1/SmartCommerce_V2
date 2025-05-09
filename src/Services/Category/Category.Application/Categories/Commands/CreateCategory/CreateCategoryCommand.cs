// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Category.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(CategoryItem Category)
    : ICommand<CreateCategoryResult>;

public record CreateCategoryResult(string CategoryId);
