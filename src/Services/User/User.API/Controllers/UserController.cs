// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace User.API.Controllers;

[ApiController]
[Route("user")]
public sealed class UserController : ControllerBase
{
    [HttpGet("{userId}")]
    public async Task<string> GetUser(string userId)
    {
        return await Task.Run(() => $"Get user route: {userId}");
    }
}
