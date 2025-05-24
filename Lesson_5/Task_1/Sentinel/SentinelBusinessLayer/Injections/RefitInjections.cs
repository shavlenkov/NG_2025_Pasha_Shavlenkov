using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SentinelBusinessLayer.Clients;

namespace SentinelBusinessLayer.Injections;
public static class RefitInjections
{
    //private static readonly TreatmentClientSettings _treatmentSettings;

    public static void AddRefitClients(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        //_treatmentSettings = treatmentOptions.Value ?? throw new ArgumentNullException(nameof(treatmentOptions));
        
        services.AddRefitClient<IPetClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7225"));
        
        services.AddRefitClient<IStoreClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7171"));
        
        services.AddRefitClient<IHealthCareClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7164"));
        
        services.AddRefitClient<IVendorClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7155"));
    }
}
