namespace SafariRest.Database.Context;

using Microsoft.EntityFrameworkCore;
using SafariRest.Database.Models;

public class MainContext(DbContextOptions<MainContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
}
