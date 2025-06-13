using System.Security.Claims;
using ToDo.Models.Entities;

namespace ToDo.Configuration;

public class CurrentUserMiddleware
{
    private readonly RequestDelegate _next;

    public CurrentUserMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, CurrentUser currentUser)
    {
        var user = context.User;
        if (user.Identity?.IsAuthenticated == true)
        {
            currentUser.UserId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());
            currentUser.Username = user.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
        }

        await _next(context);
    }
}