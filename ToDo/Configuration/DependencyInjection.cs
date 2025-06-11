using Microsoft.EntityFrameworkCore;
using ToDo.Data;

namespace ToDo.Configuration;

public static class DependencyInjection
{
    public static void DependencyInjectionInit(this IServiceCollection services, IConfiguration configuration)
    {
        #region DB
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
            configuration.GetConnectionString("DefaultConnection")));
        #endregion
        
        // #region Services
        // #endregion
        
        // #region Repositories
        // #endregion
        
        
    }
}