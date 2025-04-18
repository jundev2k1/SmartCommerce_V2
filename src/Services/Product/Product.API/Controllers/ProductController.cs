// Copyright (c) 2025 - Jun Dev. All rights reserved

using Microsoft.FeatureManagement;
using Product.Application.Dtos;
using Product.Application.Features.Products.Queries.GetProduct;

namespace Product.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ProductController : ControllerBase
{
    private ISender _sender;
    private ILogger<ProductController> _logger;
    private IFeatureManager _featureManager;

    public ProductController(ISender sender, ILogger<ProductController> logger, IFeatureManager featureManager)
    {
        _sender = sender;
        _logger = logger;
        _featureManager = featureManager;
    }

    [HttpGet("get-by-criteria")]
    public string[] GetByCriteria()
    {
        _logger.LogInformation("GetByCriteria called");
        return Array.Empty<string>();
    }

    [HttpGet("{productId}")]
    public async Task<string> GetById(string productId)
    {
        _logger.LogInformation("GetById called with productId: {productId}", productId);

        var result = await _sender.Send(new GetProductQuery(productId));
        return result.ToString();
    }

    [HttpPost("")]
    public async Task<string> CreateProduct([FromForm] ProductDto product)
    {
        _logger.LogInformation("InsertNewProduct called");
        if (await _featureManager.IsEnabledAsync("EnableEditProduct") == false)
        {
            return "Feature is disabled";
        }

        var result = await _sender.Send(new GetProductQuery("123"));
        return result.ToString();
    }

    [HttpPut("{productId}")]
    public async Task<string> UpdateProduct(string productId, [FromForm] ProductDto product)
    {
        _logger.LogInformation("UpdateProduct called");
        if (await _featureManager.IsEnabledAsync("EnableEditProduct") == false)
        {
            return "Feature is disabled";
        }

        var result = await _sender.Send(new GetProductQuery(productId));
        return result.ToString();
    }

    [HttpDelete("{productId}")]
    public async Task<string> DeleteProduct(string productId)
    {
        _logger.LogInformation("DeleteProduct called");
        if (await _featureManager.IsEnabledAsync("EnableEditProduct") == false)
        {
            return "Feature is disabled";
        }

        var result = await _sender.Send(new GetProductQuery(productId));
        return result.ToString();
    }
}
