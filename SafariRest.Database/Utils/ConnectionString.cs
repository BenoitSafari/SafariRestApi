using Microsoft.Extensions.Configuration;

namespace SafariRest.Database.Utils;

public static class ConnectionString
{
    public static string GetConnectionString(IConfiguration cfg) =>
        GetConnectionStringFromEnv()
        ?? cfg.GetConnectionString("Default")
        ?? throw new InvalidOperationException(
            "No connection string found in env/appsettings files"
        );

    public static string? GetConnectionStringFromEnv()
    {
        var user = Environment.GetEnvironmentVariable("POSTGRES_USER");
        var pass = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
        var db = Environment.GetEnvironmentVariable("POSTGRES_DB");
        var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
        var port = Environment.GetEnvironmentVariable("POSTGRES_PORT");

        return user is null || pass is null || db is null || host is null || port is null
            ? null
            : $"Host={host};Username={user};Password={pass};Database={db};Port={port};";
    }
}
