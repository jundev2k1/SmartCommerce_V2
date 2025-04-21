// Copyright (c) 2025 - Jun Dev. All rights reserved

using Microsoft.FeatureManagement;
using Product.Application.Dtos;
using Product.Application.Features.Products.Queries.GetProduct;

namespace Product.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ProductController(
    ISender sender,
    ILogger<ProductController> logger,
    IFeatureManager featureManager) : ControllerBase
{
    [HttpGet("get-by-criteria")]
    public string[] GetByCriteria()
    {
        logger.LogInformation("GetByCriteria called");
        return Array.Empty<string>();
    }

    [HttpGet("{productId}")]
    public async Task<string> GetById(string productId)
    {
        logger.LogInformation("GetById called with productId: {productId}", productId);

        var result = await sender.Send(new GetProductQuery(productId));
        return result.ToString();
    }

    [HttpPost("")]
    public async Task<string> CreateProduct([FromForm] ProductDto product)
    {
        logger.LogInformation("InsertNewProduct called");
        if (await featureManager.IsEnabledAsync("EnableEditProduct") == false)
        {
            return "Feature is disabled";
        }

        var result = await sender.Send(new GetProductQuery("123"));
        return result.ToString();
    }

    [HttpPut("{productId}")]
    public async Task<string> UpdateProduct(string productId, [FromForm] ProductDto product)
    {
        logger.LogInformation("UpdateProduct called");
        if (await featureManager.IsEnabledAsync("EnableEditProduct") == false)
        {
            return "Feature is disabled";
        }

        var result = await sender.Send(new GetProductQuery(productId));
        return result.ToString();
    }

    [HttpDelete("{productId}")]
    public async Task<string> DeleteProduct(string productId)
    {
        logger.LogInformation("DeleteProduct called");
        if (await featureManager.IsEnabledAsync("EnableEditProduct") == false)
        {
            return "Feature is disabled";
        }

        var result = await sender.Send(new GetProductQuery(productId));
        return result.ToString();
    }
}
