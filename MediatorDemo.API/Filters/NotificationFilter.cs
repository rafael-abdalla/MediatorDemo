using MediatorDemo.Domain.Notifications;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;

namespace MediatorDemo.API.Filters;

public class NotificationFilter : IAsyncResultFilter
{
    private readonly NotificationContext _notificationContext;

    public NotificationFilter(NotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (_notificationContext.HasNotifications)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.HttpContext.Response.ContentType = "application/json";

            var notifications = _notificationContext.Notifications
                .GroupBy(x => new { x.Key })
                .Select(x => new
                {
                    x.Key.Key,
                    Messages = x.Select(x => x.Message)
                })
                .ToList();

            var json = JsonSerializer.Serialize(notifications);

            await context.HttpContext.Response.WriteAsync(json);

            return;
        }

        await next();
    }
}
