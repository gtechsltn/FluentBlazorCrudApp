using FluentBlazorApp.Application.Interfaces;
using FluentBlazorApp.Domain.Entities;

namespace FluentBlazorApp.Application.UseCases;

public class WeatherService : IWeatherService
{
    private readonly IUnitOfWork _unitOfWork;

    public WeatherService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync(DateOnly startDate)
    {
        return await _unitOfWork.WeatherForecasts.GetForecastsAsync(startDate);
    }

    public async Task SaveForecastsAsync(IEnumerable<WeatherForecast> forecasts)
    {
        await _unitOfWork.WeatherForecasts.AddForecastsAsync(forecasts);
    }

    public async Task SaveForecastsWithRelatedDataAsync(IEnumerable<WeatherForecast> newForecasts)
    {
        // Begin the transaction
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            // First database operation: Add new forecasts
            await _unitOfWork.WeatherForecasts.AddForecastsAsync(newForecasts);

            // Second database operation: Update other related data
            // await _unitOfWork.SomeOtherRepository.UpdateAsync(...);

            // If both operations succeed, commit the transaction
            await _unitOfWork.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            // If any operation fails, roll back the transaction
            await _unitOfWork.RollbackTransactionAsync();
            // Re-throw the exception to notify the caller
            throw new InvalidOperationException("Failed to save weather forecasts and related data.", ex);
        }
    }
}