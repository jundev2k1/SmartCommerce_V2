// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Product.Application.Features.Products.Queries.GetProduct;

public record GetProductQuery(string productId)
    : IQuery<GetProductResult>;

public record GetProductResult(ProductDto Product);