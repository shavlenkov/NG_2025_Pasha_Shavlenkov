using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Services.Interfaces;

public interface IStoreService
{
    Task<IEnumerable<StoreDto>> GetAllStores();
    Task<StoreDto> GetStoreById(Guid id);
    Task<StoreDto> UpdateStore(Guid id, StoreDto storeDto);
    Task<StoreDto> GetStorePets(Guid id);
    Task<StoreDto> GetStoreHealthcareRecords(Guid id);
}