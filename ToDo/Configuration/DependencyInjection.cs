using Microsoft.EntityFrameworkCore;
using ToDo.Data;
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
        
        #region Services

        services.AddScoped<ITodoService, TodoService>();

        #endregion

        #region Repositories

        services.AddScoped<ITodoRepository, TodoRepository>();

        #endregion


    }
}