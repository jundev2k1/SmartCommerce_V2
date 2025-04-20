﻿// Copyright (c) 2025 - Jun Dev. All rights reserved

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
