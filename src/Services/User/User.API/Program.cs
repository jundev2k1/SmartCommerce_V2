// Copyright (c) 2025 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Server.Kestrel.Core;
using User.API;
using User.Application;
using User.Infrastructure;

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
builder.Services.AddApplication(builder.Configuration)
	.AddInfrastructure(builder.Configuration)
	.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices();

app.Run();
