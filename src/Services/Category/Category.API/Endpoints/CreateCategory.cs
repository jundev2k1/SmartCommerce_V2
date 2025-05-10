// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Categories.Commands.CreateCategory;
using Category.Application.Categories.Dtos;
using Category.Domain.ValueObjects;

namespace Category.API.Endpoints;

public record CreateCategoryResult(string CategoryId);

public sealed class CreateCategory : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/category", async (
			[FromBody] CategoryDto category,
			[FromServices] ISender sender,
			[FromServices] ILogger<CreateCategory> logger) =>
		{
			logger.LogInformation(
				"Create category with data: {Data}",
				JsonConvert.SerializeObject(category));

			var input = CategoryItem.Create(
				categoryId: CategoryId.Of(category.Id),
				parentId: CategoryId.Of(category.ParentId),
				name: category.Name,
				avatar: category.Avatar,
				desc: category.Description,
				priority: category.Priority,
				createdBy: category.CreatedBy ?? string.Empty,
				lastModifiedBy: category.LastModifiedBy ?? string.Empty,
				createdAt: DateTime.UtcNow,
				lastModified: DateTime.UtcNow,
				validFlg: category.ValidFlg,
				delFlg: category.DelFlg);
			var result = await sender.Send(new CreateCategoryCommand(input));

			return new CreateCategoryResult(result.CategoryId);
		});
	}
}
