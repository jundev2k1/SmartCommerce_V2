// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Product.Application.Dtos;
public record ProductDto(
	string ProductId,
	string Name,
	string ShortDescription,
	string Description,
	decimal Price);
