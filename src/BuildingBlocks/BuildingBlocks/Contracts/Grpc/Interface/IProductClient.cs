// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc.Product;

namespace BuildingBlocks.Contracts.Grpc.Interface;

public interface IProductClient
{
	Task<GetProductResponse> GetProductAsync(GetProductRequest request, CancellationToken cancellationToken = default);

	Task<GetProductsResponse> GetProductsAsync(GetProductsRequest request, CancellationToken cancellationToken = default);
}
