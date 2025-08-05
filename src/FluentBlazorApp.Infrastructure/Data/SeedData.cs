using System.Data;

using FluentBlazorApp.Application.Interfaces;
using FluentBlazorApp.Domain.Entities;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FluentBlazorApp.Infrastructure.Data;

public class SeedData : ISeedData
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<SeedData> _logger;

    public SeedData(ApplicationDbContext context, ILogger<SeedData> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        if (await _context.WeatherForecasts.AnyAsync())
        {
            return;
        }

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        }).ToArray();

        try
        {
            _context.WeatherForecasts.AddRange(forecasts);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Database seeded successfully with initial data.");
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
    }
}
