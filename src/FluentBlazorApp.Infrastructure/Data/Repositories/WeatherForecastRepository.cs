using Dapper;

using FluentBlazorApp.Application.Interfaces;
using FluentBlazorApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace FluentBlazorApp.Infrastructure.Data.Repositories;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly ApplicationDbContext _db;

    public WeatherForecastRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync(DateOnly startDate)
    {
        // return await _context.WeatherForecasts.Where(f => f.Date >= startDate).ToListAsync();

        var sql = "SELECT * FROM WeatherForecasts WHERE Date >= @StartDate";
        var startDateTime = startDate.ToDateTime(TimeOnly.MinValue);
        using (var connection = _db.Database.GetDbConnection())
        {
            return await connection.QueryAsync<WeatherForecast>(sql, new { StartDate = startDateTime });
        }
    }

    public async Task AddForecastsAsync(IEnumerable<WeatherForecast> forecasts)
    {
        _db.WeatherForecasts.AddRange(forecasts);
        await _db.SaveChangesAsync();
    }
}
