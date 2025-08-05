using FluentBlazorApp.Application.Interfaces;
using FluentBlazorApp.Application.Services;
using FluentBlazorApp.Domain.Entities;

namespace FluentBlazorApp.Infrastructure.Services;

public class WeatherService : IWeatherService
{
    private readonly IWeatherForecastRepository _repository;

    public WeatherService(IWeatherForecastRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync(DateOnly startDate)
    {
        return await _repository.GetForecastsAsync(startDate);
    }

    public async Task SaveForecastsAsync(IEnumerable<WeatherForecast> forecasts)
    {
        await _repository.AddForecastsAsync(forecasts);
    }

    public async Task SaveForecastsWithRelatedDataAsync(IEnumerable<WeatherForecast> newForecasts)
    {
        await _repository.AddForecastsAsync(newForecasts);
    }
}
