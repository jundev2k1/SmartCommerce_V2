// Copyright (c) 2025 - Jun Dev. All rights reserved

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
            logger.LogInformation("Get category with id: {Id}", categoryId);

            var result = await sender.Send(new GetCategoryByIdQuery(categoryId));

            return result.Category;
        });
    }
}
