// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Product.Application.Features.Products.Queries.GetProductsByCriteriaQuery;

public record GetProductsByCriteriaQuery()
	: IQuery<GetProductsResult>;

public record GetProductsResult(ProductDto[] Products);