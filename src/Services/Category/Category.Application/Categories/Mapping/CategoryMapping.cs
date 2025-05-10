// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Categories.Dtos;

namespace Category.Application.Categories.Mapping;

public sealed class CategoryMapping : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CategoryItem, CategoryDto>()
			.Map(dest => dest.ParentId, src => src.ParentId.Value)
			.Map(dest => dest.Id, src => src.Id.Value);
	}
}
