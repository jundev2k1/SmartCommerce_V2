// Copyright (c) 2025 - Jun Dev. All rights reserved

using System.Reflection;
using DbUp;

namespace Product.Infrastructure.Data.Migrations;

public static class MigrationRunner
{
    public static void Run(string connectionString)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(assembly, name => name.EndsWith(".pgsql"))
            .LogToConsole()
            .Build();
        upgrader.PerformUpgrade();
    }
}
