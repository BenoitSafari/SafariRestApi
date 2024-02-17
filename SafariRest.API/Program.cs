using Microsoft.EntityFrameworkCore;
using SafariRest.API.Utils;
using SafariRest.Database.Context;

internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        var builder = new AppBuilder(args);
        var app = builder.BuildApp();

        RegisterServices(app);
        await ApplyDataMigrationsAsync(app);

        if (app.Environment.IsDevelopment())
            SetDevelopmentEnv(app);

        app.Run();
    }

    private static void SetDevelopmentEnv(WebApplication app) { }

    private static void RegisterServices(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseStaticFiles();
        app.UseCors();
        app.UseAuthorization();
        app.MapControllers();
    }

    private static async Task ApplyDataMigrationsAsync(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MainContext>();
        await context.Database.MigrateAsync();
    }
}
