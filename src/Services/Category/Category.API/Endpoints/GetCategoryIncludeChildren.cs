// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Application.Categories.Queries.GetCategoryIncludeChildren;
using Mapster;

namespace Category.API.Endpoints;

public record GetCategoryIncludeChildrenResponse(IEnumerable<CategoryItem> categories);

public sealed class GetCategoryIncludeChildren() : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/category/{categoryId}/children", async (string categoryId, ISender sender) =>
        {
            var result = await sender.Send(new GetCategoryIncludeChildrenQuery(categoryId));
            var response = result.Adapt<GetCategoryIncludeChildrenResponse>();
            return response;
        });
    }
}
