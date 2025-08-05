using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Components.Tooltip;

using RouteService = FluentBlazorCrudApp.Services.RouteService;
using StateContainer = FluentBlazorCrudApp.Services.StateContainer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddFluentUIComponents();

// Custom services
builder.Services.AddTransient<RouteService>();
builder.Services.AddSingleton<StateContainer>();
builder.Services.AddScoped<ITooltipService, TooltipService>();
builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddScoped<IToastService, ToastService>();

var app = builder.Build();

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
