namespace Category.API.Endpoints;

public record GetCategoryIncludeChildrenResponse(CategoryItem? category);

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
