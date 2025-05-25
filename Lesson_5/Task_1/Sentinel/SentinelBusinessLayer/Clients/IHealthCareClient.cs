using Refit;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Clients
{
    public interface IHealthCareClient
    {
        [Get("/api/healthcares")]
        Task<IEnumerable<HealthCareDto>> GetAllHealthCaresRecords();
        
        [Get("/api/healthcares/{id}")]
        Task<HealthCareDto> GetHealthCareById(Guid id);
        
        [Post("/api/healthcares")]
        Task<HealthCareDto> AddHealthCareRecord([Body] HealthCareDto dto);
        
        [Put("/api/healthcares/{id}")]
        Task<HealthCareDto> UpdateHealthCareRecord(Guid id, [Body] HealthCareDto dto);
        
        [Delete("/api/healthcares/{id}")]
        Task<HealthCareDto> DeleteHealthCareRecord(Guid id);
        
        [Get("/api/healthcares/by-pet/{petId}")]
        Task<IEnumerable<HealthCareDto>> GetHealthCareRecordsByPet(Guid petId);
        
        [Get("/api/healthcares/by-vendor/{vendorId}")]
        Task<IEnumerable<HealthCareDto>> GetHealthCareRecordsByVendor(Guid vendorId);
        
        [Get("/api/healthcares/expiring")]
        Task<IEnumerable<HealthCareDto>> GetExpiringHealthCareRecords();
    }
}