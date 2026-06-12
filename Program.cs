using Microsoft.EntityFrameworkCore;
using WafGateway.Data;
using WafGateway.Middleware;
using WafGateway.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// SERVICES
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddDbContext<WafDbContext>(o =>
    o.UseSqlite("Data Source=waf.db"));

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

// SIGNALR
app.MapHub<WafHub>("/wafHub");

// LOGGING MIDDLEWARE
app.UseMiddleware<WafLoggingMiddleware>();

app.MapRazorPages();

app.Run();
