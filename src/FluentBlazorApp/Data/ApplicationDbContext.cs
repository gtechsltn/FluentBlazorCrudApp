using FluentBlazorApp.Models;

using Microsoft.EntityFrameworkCore;

namespace FluentBlazorApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;
}