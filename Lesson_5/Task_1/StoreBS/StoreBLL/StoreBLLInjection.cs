using Microsoft.Extensions.DependencyInjection;
using StoreBLL.Profiles;
using StoreBLL.Services;
using StoreBLL.Services.Interfaces;

namespace StoreBLL;

public static class StoreBLLInjection
{
    public static void AddStoreBLL(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PetProfile));
        services.AddAutoMapper(typeof(StoreProfile));
        services.AddAutoMapper(typeof(HealthCareProfile));
        
        services.AddScoped<IStoreService, StoreService>();
    }
}