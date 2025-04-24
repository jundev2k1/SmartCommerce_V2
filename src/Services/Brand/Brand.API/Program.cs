// Copyright (c) 2025 - Jun Dev. All rights reserved

using Brand.API;
using Brand.Application;
using Brand.Infrastructure;
using Brand.Infrastructure.Data.Extensions;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to use HTTP/2
builder.WebHost.ConfigureKestrel(options =>
{
	options.ListenAnyIP(8080, listenOptions =>
	{
		listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
	});
});

// Add services to the container.
builder.Services.AddApplication(builder.Configuration)
	.AddInfrastructure(builder.Configuration)
	.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices();

if (app.Environment.IsDevelopment())
{
	await app.InitialiseDatabaseAsync();
}

app.Run();
