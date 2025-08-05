using System.Text;

using FluentBlazorApp.Application.Interfaces;
using FluentBlazorApp.Application.Services;
using FluentBlazorApp.Infrastructure.Data;
using FluentBlazorApp.Infrastructure.Data.Repositories;

using Microsoft.EntityFrameworkCore;

using Serilog;
using Serilog.Events;

namespace FluentBlazorApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("logs/ts-admin-.log", rollingInterval: RollingInterval.Day, encoding: Encoding.UTF8)
            .CreateLogger();

        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog();

        try
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor(options =>
            {
                options.DetailedErrors = true;
            });

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sqlServerOptions =>
                    sqlServerOptions.EnableRetryOnFailure()));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ISeedData, SeedData>();
            builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            builder.Services.AddScoped<IWeatherService, WeatherService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
                try
                {
                    var seedData = services.GetRequiredService<ISeedData>();
                    await seedData.InitializeAsync();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred during database seeding.");
                }
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();

            app.MapFallbackToPage("/_Host");

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application failed to start correctly.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
