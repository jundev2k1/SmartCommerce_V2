// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Categories.Dtos;
using Category.Application.Categories.Queries.GetCategoryById;

namespace Category.API.Endpoints;

public sealed class GetCategoryById : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/category/{categoryId}", async (
			[FromRoute] string categoryId,
			[FromServices] ISender sender,
			[FromServices] ILogger<GetCategoryById> logger) =>
		{
			logger.LogInformation("Get category with id: {categoryId}", categoryId);

			var result = await sender.Send(new GetCategoryByIdQuery(categoryId));
			var response = result.Category.Adapt<CategoryDto>();

			logger.LogInformation("Get category response:\n {response}", JsonConvert.SerializeObject(response));
			return response;
		});
	}
}
