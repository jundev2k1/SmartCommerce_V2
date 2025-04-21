// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc.Product;
using Grpc.Core;

namespace Product.Infrastructure.Grpc;

public sealed class ProductGrpcService()
    : ProductProtoService.ProductProtoServiceBase
{
    public override async Task<GetProductResponse> GetProduct(GetProductRequest request, ServerCallContext context)
    {
        return await Task.FromResult(new GetProductResponse() { Product = new ProductModel { Name = "Test grpc product" } });
    }

    public override async Task<GetProductsResponse> GetProducts(GetProductsRequest request, ServerCallContext context)
    {
        return await Task.FromResult(new GetProductsResponse());
    }
}
