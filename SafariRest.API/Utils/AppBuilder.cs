using Microsoft.EntityFrameworkCore;
using SafariRest.Database.Context;

namespace SafariRest.API.Utils;

public static class AppBuilder
{
    public static WebApplication Build(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.SetEnvironment();
        builder.AddControllers();
        builder.SetSwaggerGen();
        builder.SetCorsPolicy();
        builder.SetDatabase();
        builder.Services.InjectRepositories();
        builder.Services.InjectServices();
        return builder.Build();
    }

    private static void SetEnvironment(this WebApplicationBuilder builder)
    {
        var env = builder.Environment.EnvironmentName;
        builder
            .Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
    }

    private static void SetDatabase(this WebApplicationBuilder builder)
    {
        var connStr =
            builder.Configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException(
                "No connection string found in appsettings files"
            );

        builder.Services.AddDbContext<MainContext>(opts =>
            opts.UseNpgsql(connStr, b => b.MigrationsAssembly("SafariRest.Database"))
        );
    }

    private static void SetCorsPolicy(this WebApplicationBuilder builder)
    {
        var origins = builder.Configuration.GetCorsAllowedOrigins();
        builder.Services.AddCors(opts =>
        {
            opts.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
        });
    }

    private static void SetSwaggerGen(this WebApplicationBuilder builder) =>
        builder.Services.AddSwaggerGen(opts =>
        {
            opts.SwaggerDoc("v1", new() { Title = "SafariRest.API", Version = "v1" });
        });

    private static void AddControllers(this WebApplicationBuilder builder) =>
        builder.Services.AddControllers();

    private static string[] GetCorsAllowedOrigins(this ConfigurationManager config) =>
        config.GetSection("CorsAllowedOrigins").Get<string[]>()
        ?? throw new InvalidOperationException("No allowed origins found in appsettings files");
}
