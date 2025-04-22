// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Product.Application.Features.Products.Queries.GetProductsByCriteriaQuery;

public sealed class GetProductsByCriteriaHandler()
	: IQueryHandler<GetProductsByCriteriaQuery, GetProductsResult>
{
	public async Task<GetProductsResult> Handle(GetProductsByCriteriaQuery request, CancellationToken cancellationToken)
	{
		return await Task.Run(() => new GetProductsResult(
			new ProductDto[] { new("Pro1", "Product 1", "", "Description", 1000) }));
	}
}
