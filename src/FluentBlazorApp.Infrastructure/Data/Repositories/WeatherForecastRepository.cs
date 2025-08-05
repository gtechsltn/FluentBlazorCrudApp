using System.Data;

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
        return await _db.WeatherForecasts.Where(f => f.Date >= startDate).ToListAsync();
    }

    public async Task AddForecastsAsync(IEnumerable<WeatherForecast> forecasts)
    {
        _db.WeatherForecasts.AddRange(forecasts);
        await _db.SaveChangesAsync();
    }
}
