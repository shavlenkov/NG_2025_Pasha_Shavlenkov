using Refit;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Clients;

public interface IStoreClient
{
    [Get("/api/stores")]
    Task<IEnumerable<StoreDto>> GetAllStores();
    
    [Get("/api/stores/{id}")]
    Task<StoreDto> GetStoreById(Guid id);
    
    [Put("/api/stores/{id}")]
    Task<StoreDto> UpdateStore(Guid id, StoreDto storeDto);
    
    [Get("/api/stores/{id}/pets")]
    Task<StoreDto> GetStorePets(Guid id);
    
    [Get("/api/stores/{id}/healthcares")]
    Task<StoreDto> GetStoreHealthcareRecords(Guid id);
}