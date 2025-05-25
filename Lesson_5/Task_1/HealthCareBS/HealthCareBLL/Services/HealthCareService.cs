using AutoMapper;
using DAL_Core.Entities;
using HealthCareDAL.Repositories.Interfaces;
using HealthCareBLL.Services.Interfaces;
using HealthCareBLL.Models;

namespace HealthCareBLL.Services;

public class HealthCareService : IHealthCareService
{
    private readonly IHealthCareRepository _healthCareRepository;
    private readonly IPetRepository _petRepository;
    private readonly IVendorRepository _vendorRepository;
    private readonly IMapper _mapper;
    
    public HealthCareService(
        IHealthCareRepository healthCareRepository,
        IPetRepository petRepository,
        IVendorRepository vendorRepository,
        IMapper mapper)
    {
        _healthCareRepository = healthCareRepository;
        _petRepository = petRepository;
        _vendorRepository = vendorRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<HealthCareDto>> GetAllHealthCareRecords()
    {
        var healthCareRecords = await _healthCareRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<HealthCareDto>>(healthCareRecords);
    }
    
    public async Task<HealthCareDto> GetHealthCareRecordById(Guid id)
    {
        var healthCareRecord = await _healthCareRepository.GetByIdAsync(id);
        
        if (healthCareRecord == null)
        {
            throw new KeyNotFoundException($"Health care record with id '{id}' not found");
        }
        
        return _mapper.Map<HealthCareDto>(healthCareRecord);
    }
    
    public async Task<HealthCareDto> AddHealthCareRecord(HealthCareDto healthCareDto)
    {
        if (await _vendorRepository.GetByIdAsync(healthCareDto.VendorId) != null)
        {
            throw new InvalidOperationException($"Vendor with id '{healthCareDto.VendorId}' does not exist");
        }
        
        if (await _petRepository.GetByIdAsync(healthCareDto.PetId) != null)
        {
            throw new InvalidOperationException($"Pet with id '{healthCareDto.PetId}' does not exist");
        }
        
        var healthCareRecord = _mapper.Map<HealthCare>(healthCareDto);
        
        var addedHealthCareRecord = await _healthCareRepository.AddAsync(healthCareRecord);
        
        return _mapper.Map<HealthCareDto>(addedHealthCareRecord);
    }
    
    public async Task<HealthCareDto> UpdateHealthCareRecord(Guid id, HealthCareDto healthCareDto)
    {
        var healthCareRecord = await _healthCareRepository.GetByIdAsync(id);
        
        if (healthCareRecord == null)
        {
            throw new KeyNotFoundException($"Pet with id '{id}' was not found");
        }
        
        if (await _petRepository.GetByIdAsync(healthCareDto.PetId) != null)
        {
            throw new InvalidOperationException($"Pet with id '{healthCareDto.PetId}' does not exist");
        }
        
        if (await _vendorRepository.GetByIdAsync(healthCareDto.VendorId) != null)
        {
            throw new InvalidOperationException($"Vendor with id '{healthCareDto.VendorId}' does not exist");
        }
        
        healthCareRecord.TreatmentName = healthCareDto.TreatmentName;
        healthCareRecord.InjectedAt = healthCareDto.InjectedAt;
        healthCareRecord.ExpirationDate = healthCareDto.ExpirationDate;
        healthCareRecord.PetId = healthCareDto.PetId;
        healthCareRecord.VendorId = healthCareDto.VendorId;
        
        var updatedHealthCareRecord = await _healthCareRepository.UpdateAsync(healthCareRecord);
        
        return _mapper.Map<HealthCareDto>(updatedHealthCareRecord);
    }
    
    public async Task<IEnumerable<HealthCareDto>> GetHealthCareRecordsByPet(Guid petId)
    {
        var healthCareRecords = await _healthCareRepository.GetHealthCareRecordsByPet(petId);
        
        return _mapper.Map<IEnumerable<HealthCareDto>>(healthCareRecords);
    }
    
    public async Task<IEnumerable<HealthCareDto>> GetHealthCareRecordsByVendor(Guid vendorId)
    {
        var healthCareRecords = await _healthCareRepository.GetHealthCareRecordsByVendor(vendorId);
        
        return _mapper.Map<IEnumerable<HealthCareDto>>(healthCareRecords);
    }
    
    public async Task<HealthCareDto> DeleteHealthCareRecord(Guid id)
    {
        var healthCareRecord = await _healthCareRepository.GetByIdAsync(id);
        
        if (healthCareRecord == null)
        {
            throw new KeyNotFoundException($"Health care record with id '{id}' was not found");
        }
        
        var deletedHealthCareRecord = await _healthCareRepository.DeleteAsync(healthCareRecord);
        
        return _mapper.Map<HealthCareDto>(deletedHealthCareRecord);
    }
    
    public async Task<IEnumerable<HealthCareDto>> GetExpiringHealthCareRecords()
    {
        var healthCareRecords = await _healthCareRepository.GetExpiringHealthCareRecords();
        
        return _mapper.Map<IEnumerable<HealthCareDto>>(healthCareRecords);
    }
}
