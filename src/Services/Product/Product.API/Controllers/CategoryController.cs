// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Product.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class CategoryController(ILogger<CategoryController> logger) : ControllerBase
{
	public async Task<string[]> GetCategory(string categoryId)
	{
		logger.LogInformation("GetCategory called with categoryId: {categoryId}", categoryId);
		return await Task.FromResult(Array.Empty<string>());
	}
}
