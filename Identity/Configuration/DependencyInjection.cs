using Identity.Data;
using Identity.Repositories.Interfaces;
using Identity.Services;
using Identity.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Configuration;

public static class DependencyInjection
{
    public static void DependencyInjectionInit(this IServiceCollection services, IConfiguration configuration)
    {
        #region Db
        services.AddDbContext<AppDbContext>(opts =>
        {
            opts.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        #endregion

        #region Services
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        #endregion
        
        #region Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        #endregion
    }
}