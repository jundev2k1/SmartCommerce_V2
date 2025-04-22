// Copyright (c) 2025 - Jun Dev. All rights reserved

using System.Reflection;
using DbUp;

namespace Product.Infrastructure.Data.Migrations;

public static class MigrationRunner
{
	public static void Run(string connectionString)
	{
        //// Get the path to the migration scripts folder
        //var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //var migrationFolderPath = $@"{baseDirectory}/Data/Migrations/Scripts";
        //if (!Directory.Exists(migrationFolderPath))
        //{
        //    return;
        //}

        //// Connection string to the database
        //var upgrader = DeployChanges.To.PostgresqlDatabase(connectionString);

        //// Get the assembly containing the migration scripts
        //var migrationDirectories = Directory.GetDirectories(migrationFolderPath)
        //    .OrderBy(dirPath => dirPath)
        //    .ToList();
        //migrationDirectories.ForEach(dirPath =>
        //{
        //    upgrader.WithScriptsFromFileSystem(dirPath, name => name.EndsWith(".pgsql"));
        //});

        //// Run the migrations
        //upgrader.LogToConsole()
        //    .Build()
        //    .PerformUpgrade();

        var upgrader = DeployChanges.To.PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(
                Assembly.GetExecutingAssembly(),
                s => s.EndsWith(".pgsql"))
            .LogToConsole()
            .Build();
        upgrader.PerformUpgrade();

    }
}
