using SentinelBusinessLayer.Injections;
using SentinelAbstraction.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRefitClients(builder.Configuration);
builder.Services.AddSentinelServices();

builder.Services.Configure<PetClientSettings>(
    builder.Configuration.GetSection("RefitClients")
        .GetSection(PetClientSettings.SectionName));
builder.Services.Configure<StoreClientSettings>(
    builder.Configuration.GetSection("RefitClients")
        .GetSection(StoreClientSettings.SectionName));
builder.Services.Configure<HealthCareClientSettings>(
    builder.Configuration.GetSection("RefitClients")
        .GetSection(HealthCareClientSettings.SectionName));
builder.Services.Configure<VendorClientSettings>(
    builder.Configuration.GetSection("RefitClients")
        .GetSection(VendorClientSettings.SectionName));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.MapStaticAssets();
app.MapControllers();

app.Run();
