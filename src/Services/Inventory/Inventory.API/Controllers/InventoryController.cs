// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Inventory.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class InventoryController : ControllerBase
{
    [HttpGet("{productId}/variant/{variantId}")]
    public async Task<string[]> GetStocks(string productId, string variantId)
    {
        return await Task.Run(() => Array.Empty<string>());
    }

    [HttpGet("{ProductId}")]
    public async Task<string[]> GetStocks(string ProductId)
    {
        return await Task.Run(() => Array.Empty<string>());
    }

    public async Task<string> Update(string BranchId, string ProductId)
    {
        return await Task.Run(() => string.Empty);
    }
}
