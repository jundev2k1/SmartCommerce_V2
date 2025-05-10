// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Categories.Commands.UpdateCategory;
using Category.Application.Categories.Dtos;
using Category.Domain.ValueObjects;

namespace Category.API.Endpoints;

public sealed class UpdateCategory : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPut("/category/{id}", async (
			[FromRoute] string id,
			[FromBody] CategoryDto category,
			[FromServices] ISender sender,
			[FromServices] ILogger<UpdateCategory> logger) =>
		{
			logger.LogInformation(
				"Update category with id: {Id}, data: {Data}",
				id,
				JsonConvert.SerializeObject(category));
			var input = CategoryItem.Create(
				categoryId: CategoryId.Of(id),
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
			await sender.Send(new UpdateCategoryCommand(input));
		});
	}
}
