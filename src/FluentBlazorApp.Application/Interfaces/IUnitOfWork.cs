using System.Data;

namespace FluentBlazorApp.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IWeatherForecastRepository WeatherForecasts { get; }
    IDbConnection Connection { get; }
    IDbTransaction Transaction { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}