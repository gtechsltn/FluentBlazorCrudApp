using System.Data;
using System.Data.Common;

using FluentBlazorApp.Application.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FluentBlazorApp.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    private readonly IWeatherForecastRepository _weatherForecasts;
    private DbConnection _connection;
    private IDbTransaction _transaction;

    public UnitOfWork(ApplicationDbContext db, IWeatherForecastRepository weatherForecasts)
    {
        _db = db;
        _weatherForecasts = weatherForecasts;
    }

    public IWeatherForecastRepository WeatherForecasts => _weatherForecasts;

    public IDbConnection Connection => _db.Database.GetDbConnection();

    public IDbTransaction Transaction => _db.Database.CurrentTransaction?.GetDbTransaction();

    public async Task BeginTransactionAsync()
    {
        await _db.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _db.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _db.Database.RollbackTransactionAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
