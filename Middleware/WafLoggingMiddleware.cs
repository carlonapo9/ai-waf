using WafGateway.Data;
using WafGateway.Models;
using Microsoft.AspNetCore.SignalR;
using WafGateway.Hubs;


namespace WafGateway.Middleware;

public class WafLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public WafLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

public async Task InvokeAsync(HttpContext context, WafDbContext db, IHubContext<WafHub> hub)
{
    var log = new WafLog
    {
        Ip = context.Connection.RemoteIpAddress?.ToString(),
        Path = context.Request.Path,
        Method = context.Request.Method,
        StatusCode = 0,
        Timestamp = DateTime.UtcNow
    };

    await _next(context);

    log.StatusCode = context.Response.StatusCode;

    db.Logs.Add(log);
    await db.SaveChangesAsync();

    await hub.Clients.All.SendAsync("ReceiveLog", log);
}

}
