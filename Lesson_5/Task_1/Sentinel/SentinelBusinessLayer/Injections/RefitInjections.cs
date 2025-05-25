using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SentinelAbstraction.Settings;
using SentinelBusinessLayer.Clients;

namespace SentinelBusinessLayer.Injections;

public static class RefitInjections
{
    public static void AddRefitClients(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var refitClients = configuration.GetSection("RefitClients");
        
        var petClientSettings = refitClients.GetSection(PetClientSettings.SectionName)
            .Get<PetClientSettings>() ?? throw new ArgumentNullException(nameof(PetClientSettings));
        var storeClientSettings = refitClients.GetSection(StoreClientSettings.SectionName)
            .Get<StoreClientSettings>() ?? throw new ArgumentNullException(nameof(StoreClientSettings));
        var healthCareClientSettings = refitClients.GetSection(HealthCareClientSettings.SectionName)
            .Get<HealthCareClientSettings>() ?? throw new ArgumentNullException(nameof(HealthCareClientSettings));
        var vendorClientSettings = refitClients.GetSection(VendorClientSettings.SectionName)
            .Get<VendorClientSettings>() ?? throw new ArgumentNullException(nameof(VendorClientSettings));
        
        services.AddRefitClient<IPetClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(petClientSettings.BaseAddress));
        services.AddRefitClient<IStoreClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(storeClientSettings.BaseAddress));
        services.AddRefitClient<IHealthCareClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(healthCareClientSettings.BaseAddress));
        services.AddRefitClient<IVendorClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(vendorClientSettings.BaseAddress));
    }
}
