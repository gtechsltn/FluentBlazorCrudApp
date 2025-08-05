using FluentBlazorApp.Application.Interfaces;
using FluentBlazorApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace FluentBlazorApp.Infrastructure.Data.Repositories;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly ApplicationDbContext _context;

    public WeatherForecastRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync(DateOnly startDate)
    {
        return await _context.WeatherForecasts.Where(f => f.Date >= startDate).ToListAsync();
    }

    public async Task AddForecastsAsync(IEnumerable<WeatherForecast> forecasts)
    {
        _context.WeatherForecasts.AddRange(forecasts);
        await _context.SaveChangesAsync();
    }
}
