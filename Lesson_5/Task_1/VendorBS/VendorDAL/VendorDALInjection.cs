using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DAL_Core;
using VendorDAL.Repositories;
using VendorDAL.Repositories.Interfaces;

namespace VendorDAL;

public static class VendorDALInjection
{
    public static void AddVendorDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PetStoreDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"))
        );
        
        services.AddScoped<IVendorRepository, VendorRepository>();
    }
}