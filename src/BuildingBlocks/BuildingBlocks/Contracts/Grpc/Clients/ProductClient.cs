// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc.Interface;
using BuildingBlocks.Contracts.Grpc.Product;

namespace BuildingBlocks.Contracts.Grpc.Clients;

public sealed class ProductClient(ProductProtoService.ProductProtoServiceClient client) : IProductClient
{
	public async Task<GetProductResponse> GetProductAsync(GetProductRequest request, CancellationToken cancellationToken = default)
	{
		return await client.GetProductAsync(request, cancellationToken: cancellationToken);
	}

	public async Task<GetProductsResponse> GetProductsAsync(GetProductsRequest request, CancellationToken cancellationToken = default)
	{
		return await client.GetProductsAsync(request, cancellationToken: cancellationToken);
	}
}