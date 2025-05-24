using HealthCareBLL.Models;

namespace HealthCareBLL.Services.Interfaces;

public interface IHealthCareService
{
    Task<IEnumerable<HealthCareDto>> GetAllHealthCareRecords();
    Task<HealthCareDto> GetHealthCareRecordById(Guid id);
    Task<HealthCareDto> AddHealthCareRecord(HealthCareDto petDto);
    Task<HealthCareDto> UpdateHealthCareRecord(Guid id, HealthCareDto healthCareDto);
    Task<HealthCareDto> DeleteHealthCareRecord(Guid id);
    Task<IEnumerable<HealthCareDto>> GetHealthCareRecordsByPet(Guid petId);
    Task<IEnumerable<HealthCareDto>> GetHealthCareRecordsByVendor(Guid vendorId);
    Task<IEnumerable<HealthCareDto>> GetExpiringHealthCareRecords();
}