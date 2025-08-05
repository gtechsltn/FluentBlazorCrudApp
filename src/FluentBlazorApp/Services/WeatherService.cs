using FluentBlazorApp.Data;
using FluentBlazorApp.Models;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FluentBlazorApp.Services;

public class WeatherService
{
    private readonly ApplicationDbContext _dbContext;

    public WeatherService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
    {
        if (!await _dbContext.WeatherForecasts.AnyAsync())
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToArray();

            _dbContext.WeatherForecasts.AddRange(forecasts);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        return await _dbContext.WeatherForecasts.ToArrayAsync();
    }
}