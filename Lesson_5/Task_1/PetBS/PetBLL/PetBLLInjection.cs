using Microsoft.Extensions.DependencyInjection;
using PetBLL.Profiles;
using PetBLL.Services;
using PetBLL.Services.Interfaces;

namespace PetBLL;

public static class PetBLLInjection
{
    public static void AddPetBLL(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PetProfile));
        
        services.AddScoped<IPetService, PetService>();
    }
}