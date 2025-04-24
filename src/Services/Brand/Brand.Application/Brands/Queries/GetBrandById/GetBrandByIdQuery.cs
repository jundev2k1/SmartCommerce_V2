// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Brand.Application.Brands.Queries.GetBrandById;

public record GetBrandByIdQuery(string BrandId) : IQuery<GetCategoryByIdResult>;

public record GetCategoryByIdResult(BrandItem? Brand);
