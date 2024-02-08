namespace SafariRest.Database.Context;

using Microsoft.EntityFrameworkCore;
using SafariRest.Database.Models;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
}
