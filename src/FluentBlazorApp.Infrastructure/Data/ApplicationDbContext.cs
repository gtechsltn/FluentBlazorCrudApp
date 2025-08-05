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
    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;
}
