using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Services.Interfaces;

public interface IHealthCareService
{
    Task<IEnumerable<HealthCareDto>> GetAllHealthCareRecords();
    Task<HealthCareDto> GetHealthCareById(Guid id);
    Task<HealthCareDto> AddHealthCareRecord(HealthCareDto healthCareDto);
    Task<HealthCareDto> UpdateHealthCareRecord(Guid id, HealthCareDto healthCareDto);
    Task<IEnumerable<HealthCareDto>> GetHealthCareRecordsByPet(Guid petId);
    Task<IEnumerable<HealthCareDto>> GetHealthCareRecordsByVendor(Guid vendorId);
    Task<HealthCareDto> DeleteHealthCareRecord(Guid id);
    Task<IEnumerable<HealthCareDto>> GetExpiringHealthCareRecords();
}