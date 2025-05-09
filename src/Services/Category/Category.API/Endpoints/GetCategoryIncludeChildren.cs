// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Categories.Queries.GetCategoryIncludeChildren;

namespace Category.API.Endpoints;

public sealed class GetCategoryIncludeChildren() : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/category/{categoryId}/children", async (
            [FromRoute] string categoryId,
            [FromServices] ISender sender,
            [FromServices] ILogger<GetCategoryIncludeChildren> logger) =>
        {
            logger.LogInformation("Get category with id: {Id}", categoryId);

            var result = await sender.Send(new GetCategoryIncludeChildrenQuery(categoryId));
            return result.Items;
        });
    }
}
