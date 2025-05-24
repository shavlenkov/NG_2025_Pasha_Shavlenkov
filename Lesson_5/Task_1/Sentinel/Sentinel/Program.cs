using SentinelAbstraction.Settings;
using SentinelBusinessLayer.Injections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRefitClients(builder.Configuration);
builder.Services.AddSentinelServices();

builder.Services.Configure<PetClientSettings>(
    builder.Configuration.GetSection("RefitClients")
        .GetSection(PetClientSettings.SectionName));
builder.Services.Configure<StoreClientSettings>(
    builder.Configuration.GetSection("RefitClients")
        .GetSection(StoreClientSettings.SectionName));
builder.Services.Configure<HealthCareSettings>(
    builder.Configuration.GetSection("RefitClients")
        .GetSection(HealthCareSettings.SectionName));
builder.Services.Configure<VendorSettings>(
    builder.Configuration.GetSection("RefitClients")
        .GetSection(VendorSettings.SectionName));

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
