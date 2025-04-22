// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc;
using BuildingBlocks.Contracts.Grpc.Product;

namespace User.API.Controllers;

[ApiController]
[Route("user")]
public sealed class UserController(IGrpcClientFacade grpcClientFacade)
	: ControllerBase
{
	[HttpGet("")]
	public async Task<string> GetUsers()
	{
		var product = await grpcClientFacade.Product.GetProductAsync(new GetProductRequest
		{
			ProductId = "1"
		});
		return await Task.Run(() => $"Get users route: {product.Product.Name}");
	}

	[HttpGet("{userId}")]
	public async Task<string> GetUser(string userId)
	{
		return await Task.Run(() => $"Get user route: {userId}");
	}
}
