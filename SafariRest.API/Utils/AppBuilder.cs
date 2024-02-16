using Microsoft.EntityFrameworkCore;
using SafariRest.Database.Context;

namespace SafariRest.API.Utils;

public class AppBuilder
{
    private readonly WebApplicationBuilder Builder;
    private readonly IConfiguration Config;

    public AppBuilder(string[] args)
    {
        Builder = WebApplication.CreateBuilder(args);
        var env = Builder.Environment.EnvironmentName;
        Config = InitConfig(env);
        AddControllers();
        SetSwaggerGen();
        SetCorsPolicy();
        SetDatabase();
    }

    public WebApplication BuildApp() => Builder.Build();

    public IConfiguration GetConfig() => Config;

    private static IConfiguration InitConfig(string env)
    {
        var cfg = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        return cfg.Build();
    }

    private void SetDatabase()
    {
        var connStr =
            Config.GetConnectionString("Default")
            ?? throw new InvalidOperationException(
                "No connection string found in appsettings files"
            );

        Builder.Services.AddDbContext<MainContext>(opts =>
            opts.UseNpgsql(connStr, o => o.MigrationsAssembly("SafariRest.Database"))
        );
    }

    private void SetCorsPolicy()
    {
        var origins =
            Config.GetSection("CorsAllowedOrigins").Get<string[]>()
            ?? throw new InvalidOperationException("No allowed origins found in appsettings files");

        Builder.Services.AddCors(opts =>
        {
            opts.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
        });
    }

    private void SetSwaggerGen() =>
        Builder.Services.AddSwaggerGen(opts =>
        {
            opts.SwaggerDoc(
                "v1",
                new()
                {
                    Title = "SafariRest.API",
                    Description = $"Built on {DateTime.Now}",
                    Version = "v1"
                }
            );
        });

    private void AddControllers() => Builder.Services.AddControllers();
}
