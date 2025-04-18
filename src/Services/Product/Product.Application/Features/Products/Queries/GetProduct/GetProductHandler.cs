// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Product.Application.Features.Products.Queries.GetProduct;

public sealed class GetProductHandler()
    : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await Task.Run(() => new GetProductResult(
            new ProductDto("Pro1", "Product 1", "", "Description", 1000)));
    }
}
