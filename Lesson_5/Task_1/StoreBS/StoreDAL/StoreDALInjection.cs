using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DAL_Core;
using StoreDAL.Repositories;
using StoreDAL.Repositories.Interfaces;

namespace StoreDAL;

public static class StoreDALInjection
{
    public static void AddStoreDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PetStoreDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"))
        );
        
        services.AddScoped<IStoreRepository, StoreRepository>();
    }
}