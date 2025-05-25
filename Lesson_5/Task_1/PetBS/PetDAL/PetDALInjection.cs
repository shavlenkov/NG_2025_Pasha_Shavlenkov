using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DAL_Core;
using PetDAL.Repositories;
using PetDAL.Repositories.Interfaces;

namespace PetDAL;

public static class PetDALInjection
{
    public static void AddPetDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PetStoreDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"))
        );
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IPetRepository, PetRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
    }
}