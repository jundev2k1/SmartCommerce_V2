// Copyright (c) 2025 - Jun Dev. All rights reserveds

using System.Data;
using Npgsql;

namespace Product.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection>(option =>
            new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")));

        services.AddControllers();

        services.AddOpenApi()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return services;
    }

    public static IApplicationBuilder UseApiServices(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
        app.UseAuthorization()
            .UseSwagger()
            .UseSwaggerUI();
        app.MapControllers();
        return app;
    }
}
