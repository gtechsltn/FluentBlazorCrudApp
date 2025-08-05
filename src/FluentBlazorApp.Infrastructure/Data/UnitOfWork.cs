using System.Data;
using System.Data.Common;

using FluentBlazorApp.Application.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FluentBlazorApp.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IWeatherForecastRepository _weatherForecasts;
    private DbConnection _connection;
    private IDbTransaction _transaction;

    public UnitOfWork(ApplicationDbContext dbContext, IWeatherForecastRepository weatherForecasts)
    {
        _dbContext = dbContext;
        _weatherForecasts = weatherForecasts;
    }

    public IWeatherForecastRepository WeatherForecasts => _weatherForecasts;

    public IDbConnection Connection => _dbContext.Database.GetDbConnection();

    public IDbTransaction Transaction => _dbContext.Database.CurrentTransaction?.GetDbTransaction();

    public async Task BeginTransactionAsync()
    {
        await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _dbContext.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
