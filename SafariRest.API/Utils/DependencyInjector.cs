using SafariRest.Database.Models;
using SafariRest.Database.Repository;
using SafariRest.Services;

namespace SafariRest.API.Utils;

public static class DependencyInjector
{
    public static void InjectServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<AdminService>();
    }

    public static void InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<User>, Repository<User>>();
        services.AddScoped<IRepository<Admin>, Repository<Admin>>();
    }
}
