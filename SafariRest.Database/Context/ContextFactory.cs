using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SafariRest.Database.Context;

namespace SafariRest.Database;

public class ContextFactory : IDesignTimeDbContextFactory<MainContext>
{
    private readonly string Env =
        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

    public MainContext CreateDbContext(string[] args)
    {
        var connStr = GetConnectionString(args);
        var optionsBuilder = new DbContextOptionsBuilder<MainContext>();

        optionsBuilder.UseNpgsql(connStr);
        return new MainContext(optionsBuilder.Options);
    }

    private string GetConnectionString(string[]? args)
    {
        if (args is not null && args.Length > 0)
            return args[0];

        var config = new ConfigurationBuilder()
            .SetBasePath(GetAppSettingsPath())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Env}.json")
            .Build();

        var connStr =
            config.GetConnectionString("Default")
            ?? throw new InvalidOperationException(
                "No connection string found in appsettings files"
            );

        return connStr;
    }

    private static string GetAppSettingsPath() =>
        Path.Combine(Directory.GetCurrentDirectory(), "..", "SafariRest.API");
}
