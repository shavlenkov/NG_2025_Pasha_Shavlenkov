using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Services.Interfaces;

namespace SentinelBusinessLayer.Services;

public class StoreService: IStoreService
{
    private readonly IStoreClient _storeClient;
    
    public StoreService(IStoreClient storeClient)
    {
        _storeClient = storeClient;
    }
    
    public async Task<IEnumerable<StoreDto>> GetAllStores() => 
        await _storeClient.GetAllStores();
    
    public async Task<StoreDto> GetStoreById(Guid id) => 
        await _storeClient.GetStoreById(id);
    
    public async Task<StoreDto> UpdateStore(Guid id, StoreDto storeDto) => 
        await _storeClient.UpdateStore(id, storeDto);
    
    public async Task<StoreDto> GetStorePets(Guid storeId) => 
        await _storeClient.GetStorePets(storeId);
    
    public async Task<StoreDto> GetStoreHealthcareRecords(Guid storeId) => 
        await _storeClient.GetStoreHealthcareRecords(storeId);
}