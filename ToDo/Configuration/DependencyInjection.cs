using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models.Entities;
using ToDo.Repositories;
using ToDo.Repositories.Interfaces;
using ToDo.Services;
using ToDo.Services.Interfaces;

namespace ToDo.Configuration;

public static class DependencyInjection
{
    public static void DependencyInjectionInit(this IServiceCollection services, IConfiguration configuration)
    {
        #region DB
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
            configuration.GetConnectionString("DefaultConnection")));
        #endregion

        #region Middleware

        services.AddScoped<CurrentUser>();
        
        #endregion
        
        #region Services

        services.AddScoped<ITodoService, TodoService>();

        #endregion

        #region Repositories

        services.AddScoped<ITodoRepository, TodoRepository>();

        #endregion
    }
    public static void DependencyInjectionInit(this IApplicationBuilder app)
    {
        app.UseMiddleware<CurrentUserMiddleware>();
    }
}