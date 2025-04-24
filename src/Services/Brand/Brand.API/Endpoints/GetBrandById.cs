// Copyright (c) 2025 - Jun Dev. All rights reserved

using Brand.Application.Brands.Queries.GetBrandById;
using Mapster;

namespace Brand.API.Endpoints;

public record GetBrandByIdResponse(BrandItem? category);

public sealed class GetBrandById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/brand/{brandId}", async (string brandId, ISender sender) =>
        {
            var result = await sender.Send(new GetBrandByIdQuery(brandId));

            var response = result.Adapt<GetBrandByIdResponse>();
            return response;
        });
    }
}
