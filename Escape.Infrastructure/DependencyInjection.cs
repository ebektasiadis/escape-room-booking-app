using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Escape.Infrastructure;

public static class DependencyInjection
{
    private const string DatabaseConnectionStringKey = "Database";

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfigurationManager configurationManager)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configurationManager.GetConnectionString(DatabaseConnectionStringKey))
                .UseSnakeCaseNamingConvention()
        );


        return services;
    }
}
