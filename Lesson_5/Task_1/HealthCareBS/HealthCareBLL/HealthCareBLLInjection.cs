using Microsoft.Extensions.DependencyInjection;
using HealthCareBLL.Profiles;
using HealthCareBLL.Services;
using HealthCareBLL.Services.Interfaces;

namespace HealthCareBLL;

public static class HealthCareBLLInjection
{
    public static void AddHealthCareBLL(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(HealthCareProfile));
        
        services.AddScoped<IHealthCareService, HealthCareService>();
    }
}