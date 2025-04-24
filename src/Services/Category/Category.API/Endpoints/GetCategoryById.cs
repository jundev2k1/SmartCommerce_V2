// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Categories.Queries.GetCategoryById;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Category.API.Endpoints;

public record GetCategoryByIdResponse(CategoryItem? category);

public sealed class GetCategoryById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/category/{categoryId}", async (
            [FromRoute] string categoryId,
            [FromServices] ISender sender) =>
        {
            var result = await sender.Send(new GetCategoryByIdQuery(categoryId));

            var response = result.Adapt<GetCategoryByIdResponse>();
            return response;
        });
    }
}
