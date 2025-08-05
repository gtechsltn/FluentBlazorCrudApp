using FluentBlazorApp.Domain.Entities;

namespace FluentBlazorApp.Application.Interfaces;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>> GetForecastsAsync(DateOnly startDate);
    Task AddForecastsAsync(IEnumerable<WeatherForecast> forecasts);
}
