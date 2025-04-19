using DataAccessLayer;
using BusinessLogicLayer;
using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Initializer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    
    try 
    {
        var context = serviceProvider.GetRequiredService<CrowdfundingDbContext>();
        
        Initializer.InitializeDb(context);
    } catch (Exception exception) 
    {
        Console.Error.WriteLine($"Error: {exception.Message}");
        
        throw;
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapStaticAssets();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Category}/{action=GetAll}")
    .WithStaticAssets();

app.Run();