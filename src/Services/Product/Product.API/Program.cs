// Copyright (c) 2025 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Server.Kestrel.Core;
using Product.API;
using Product.Application;
using Product.Infrastructure;
using Product.Infrastructure.Data.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to use HTTP/2
builder.WebHost.ConfigureKestrel(options =>
{
	options.ListenAnyIP(8080, listenOptions =>
	{
		listenOptions.Protocols = HttpProtocols.Http2;
	});
});

// Add services to the container.
builder.Services
	.AddApplication(builder.Configuration)
	.AddInfrastructure(builder.Configuration)
	.AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseInfrastructure();
app.UseApiServices();

// Run migrations if in development mode
if (app.Environment.IsDevelopment())
{
	MigrationRunner.Run(
		builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty);
}

app.Run();
