// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Category.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(CategoryItem Category) : ICommand<Unit>;
