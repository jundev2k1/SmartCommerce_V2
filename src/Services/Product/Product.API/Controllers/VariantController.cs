// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc;

namespace Product.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class VariantController(
    IGrpcClientFacade grpcClientFacade,
    ILogger<CategoryController> logger) : ControllerBase
{
    [HttpGet("{productId}/variant/{variantId}")]
    public async Task<string> GetVariant(string productId, string variantId)
    {
        logger.LogInformation("Get variant called with Params: {productId}, {variantId}", productId, variantId);
        var user = await grpcClientFacade.User.GetUserAsync(new BuildingBlocks.Contracts.Grpc.User.GetUserRequest() { UserId = "user1" });
        return await Task.FromResult(user.User.UserId);
    }
}
