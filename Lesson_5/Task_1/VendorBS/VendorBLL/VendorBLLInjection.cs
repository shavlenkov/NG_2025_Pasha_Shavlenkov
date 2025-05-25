using Microsoft.Extensions.DependencyInjection;
using VendorBLL.Profiles;
using VendorBLL.Services;
using VendorBLL.Services.Interfaces;

namespace VendorBLL;

public static class VendorBLLInjection
{
    public static void AddVendorBLL(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(VendorProfile));
        services.AddAutoMapper(typeof(HealthCareProfile));
        
        services.AddScoped<IVendorService, VendorService>();
    }
}