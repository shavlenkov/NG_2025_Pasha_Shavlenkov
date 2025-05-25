using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DAL_Core;
using HealthCareDAL.Repositories;
using HealthCareDAL.Repositories.Interfaces;

namespace HealthCareDAL;

public static class HealthCareDALInjection
{
    public static void AddHealthCareDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PetStoreDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"))
        );
        
        services.AddScoped<IHealthCareRepository, HealthCareRepository>();
        services.AddScoped<IPetRepository, PetRepository>();
        services.AddScoped<IVendorRepository, VendorRepository>();
    }
}