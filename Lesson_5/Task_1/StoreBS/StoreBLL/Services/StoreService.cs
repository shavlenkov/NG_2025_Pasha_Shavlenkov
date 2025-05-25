using AutoMapper;
using StoreDAL.Repositories.Interfaces;
using StoreBLL.Services.Interfaces;
using StoreBLL.Models;

namespace StoreBLL.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    
    public StoreService(
        IStoreRepository storeRepository,
        IMapper mapper)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<StoreDto>> GetAllStores()
    {
        var stores = await _storeRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<StoreDto>>(stores);
    }
    
    public async Task<StoreDto> GetStoreById(Guid id)
    {
        var store = await _storeRepository.GetByIdAsync(id);
        
        if (store == null)
        {
            throw new KeyNotFoundException($"Store with id '{id}' not found");
        }
        
        return _mapper.Map<StoreDto>(store);
    }
    
    public async Task<StoreDto> UpdateStore(Guid id, StoreDto storeDto)
    {
        var store = await _storeRepository.GetByIdAsync(id);
        
        if (store == null)
        {
            throw new KeyNotFoundException($"Store with id '{id}' was not found");
        }
        
        store.Name = storeDto.Name;
        store.Description = storeDto.Description;
        store.City = storeDto.City;
        store.Address = storeDto.Address;
        
        var updatedStore = await _storeRepository.UpdateAsync(store);
        
        return _mapper.Map<StoreDto>(updatedStore);
    }
    
    public async Task<IEnumerable<PetDto>> GetStorePets(Guid storeId)
    {
        var pets = await _storeRepository.GetStorePetsAsync(storeId);
        
        return _mapper.Map<IEnumerable<PetDto>>(pets);
    }
    
    public async Task<IEnumerable<HealthCareDto>> GetStoreHealthCareRecords(Guid storeId)
    {
        var healthCaresRecords = await _storeRepository.GetStoreHealthCaresRecordsAsync(storeId);
        
        return _mapper.Map<IEnumerable<HealthCareDto>>(healthCaresRecords);
    }
}