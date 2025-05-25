using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Services.Interfaces;

namespace SentinelBusinessLayer.Services;

public class HealthCareService : IHealthCareService
{
    private readonly IHealthCareClient _healthCareClient;
    
    public HealthCareService(IHealthCareClient healthCareClient)
    {
        _healthCareClient = healthCareClient;
    }
    
    public async Task<IEnumerable<HealthCareDto>> GetAllHealthCareRecords() => 
        await _healthCareClient.GetAllHealthCaresRecords();
    
    public async Task<HealthCareDto> GetHealthCareById(Guid id) => 
        await _healthCareClient.GetHealthCareById(id);
    
    public async Task<HealthCareDto> AddHealthCareRecord(HealthCareDto healthCareDto) => 
        await _healthCareClient.AddHealthCareRecord(healthCareDto);
    
    public async Task<HealthCareDto> UpdateHealthCareRecord(Guid id, HealthCareDto healthCareDto) => 
        await _healthCareClient.UpdateHealthCareRecord(id, healthCareDto);
    
    public async Task<IEnumerable<HealthCareDto>> GetHealthCareRecordsByPet(Guid petId) => 
        await _healthCareClient.GetHealthCareRecordsByPet(petId);
    
    public async Task<IEnumerable<HealthCareDto>> GetHealthCareRecordsByVendor(Guid vendorId) => 
        await _healthCareClient.GetHealthCareRecordsByVendor(vendorId);
    
    public async Task<HealthCareDto> DeleteHealthCareRecord(Guid id) => 
        await _healthCareClient.DeleteHealthCareRecord(id);
    
    public async Task<IEnumerable<HealthCareDto>> GetExpiringHealthCareRecords() => 
        await _healthCareClient.GetExpiringHealthCareRecords();
}