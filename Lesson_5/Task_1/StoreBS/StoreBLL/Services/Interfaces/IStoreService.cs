using StoreBLL.Models;

namespace StoreBLL.Services.Interfaces;

public interface IStoreService
{
    Task<IEnumerable<StoreDto>> GetAllStores();
    Task<StoreDto> GetStoreById(Guid id);
    Task<StoreDto> UpdateStore(Guid id, StoreDto storeDto);
    Task<IEnumerable<PetDto>> GetStorePets(Guid storeId);
    Task<IEnumerable<HealthCareDto>> GetStoreHealthCareRecords(Guid storeId);
}