using FluentBlazorApp.Domain.Entities;

namespace FluentBlazorApp.Application.Interfaces;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetForecastsAsync(DateOnly startDate);
    Task SaveForecastsAsync(IEnumerable<WeatherForecast> forecasts);
    Task SaveForecastsWithRelatedDataAsync(IEnumerable<WeatherForecast> newForecasts);
}
