using System.Text;

using Dapper;

using FluentBlazorApp.Application.Interfaces;
using FluentBlazorApp.Application.Services;
using FluentBlazorApp.Infrastructure.Authorization;
using FluentBlazorApp.Infrastructure.Dapper;
using FluentBlazorApp.Infrastructure.Data;
using FluentBlazorApp.Infrastructure.Data.Repositories;
using FluentBlazorApp.Infrastructure.Security;
using FluentBlazorApp.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
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
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sqlServerOptions =>
                    sqlServerOptions.EnableRetryOnFailure()));

            builder.Services.AddSingleton<IAuthorizationPolicyProvider, CustomPolicyProvider>();
            builder.Services.AddSingleton<IAuthorizationHandler, CustomRequirementHandler>();

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<CustomAuthenticationStateProvider>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
            });

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new CustomRequirement("Admin"));
                });
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ISeedData, SeedData>();

            builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IUserAgentParserService, UserAgentParserService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor(options =>
            {
                options.DetailedErrors = true;
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
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
                        throw;
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
                        throw;
                    }
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

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
