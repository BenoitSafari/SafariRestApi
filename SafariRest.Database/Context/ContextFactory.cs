using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SafariRest.Database.Context;
using SafariRest.Database.Utils;

namespace SafariRest.Database;

public class ContextFactory : IDesignTimeDbContextFactory<MainContext>
{
    public MainContext CreateDbContext(string[] args)
    {
        var connStr = args.Length > 0 ? args[0] : ConnectionString.GetConnectionStringFromEnv();
        var optionsBuilder = new DbContextOptionsBuilder<MainContext>();
        optionsBuilder.UseNpgsql(connStr);
        return new MainContext(optionsBuilder.Options);
    }
}
