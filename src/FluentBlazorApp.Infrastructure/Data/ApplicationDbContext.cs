using FluentBlazorApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace FluentBlazorApp.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<User> Roles { get; set; } = default!;
    public DbSet<UserRole> UserRoles { get; set; } = default!;
    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Always call the base method

        // Using the Fluent API in OnModelCreating to SET all the table names
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<UserRole>().ToTable("UserRoles");
        modelBuilder.Entity<WeatherForecast>().ToTable("WeatherForecasts");

        // Method 1: Manually apply each configuration (good for a small number of entities)
        // modelBuilder.ApplyConfiguration(new UsersConfiguration());
        // modelBuilder.ApplyConfiguration(new ProductsConfiguration());
        // modelBuilder.ApplyConfiguration(new OrdersConfiguration());

        // Method 2: Automatically apply all configurations from the current assembly
        // This is the recommended and more scalable approach.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
