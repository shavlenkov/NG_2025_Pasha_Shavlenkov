using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL_Core;

namespace DAL_Initializator;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        
        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            
            try
            {
                var context = serviceProvider.GetRequiredService<PetStoreDbContext>();
                
                context.Database.EnsureCreated();
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine($"Error message: {exception.Message}");
                
                throw;
            }
        }
        
        Console.WriteLine("Database ensured!");
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(config =>
            {
                config.AddUserSecrets<Program>();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<PetStoreDbContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("DbConnectionString")));
            });
    }
}