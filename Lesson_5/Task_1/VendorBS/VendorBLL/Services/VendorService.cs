using AutoMapper;
using DAL_Core.Entities;
using DAL_Core.Enums;
using VendorDAL.Repositories.Interfaces;
using VendorBLL.Services.Interfaces;
using VendorBLL.Models;

namespace VendorBLL.Services;

public class VendorService : IVendorService
{
    private readonly IVendorRepository _vendorRepository;
    private readonly IMapper _mapper;
    
    public VendorService(
        IVendorRepository vendorRepository,
        IMapper mapper)
    {
        _vendorRepository = vendorRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<VendorDto>> GetAllVendors()
    {
        var vendors = await _vendorRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<VendorDto>>(vendors);
    }
    
    public async Task<VendorDto> GetVendorById(Guid id)
    {
        var vendor = await _vendorRepository.GetByIdAsync(id);
        
        if (vendor == null)
        {
            throw new KeyNotFoundException($"Vendor with id '{id}' not found");
        }
        
        return _mapper.Map<VendorDto>(vendor);
    }
    
    public async Task<VendorDto> AddVendor(VendorDto vendorDto)
    {
        var vendor = _mapper.Map<Vendor>(vendorDto);
        
        var addedVendor = await _vendorRepository.AddAsync(vendor);
        
        return _mapper.Map<VendorDto>(addedVendor);
    }
    
    public async Task<VendorDto> UpdateVendor(Guid id, VendorDto vendorDto)
    {
        var vendor = await _vendorRepository.GetByIdAsync(id);
        
        if (vendor == null)
        {
            throw new KeyNotFoundException($"Vendor with id '{id}' was not found");
        }
        
        vendor.Name = vendorDto.Name;
        vendor.Description = vendorDto.Description;
        vendor.SignedAt = vendorDto.SignedAt;
        vendor.ExpirationDate = vendorDto.ExpirationDate;
        vendor.ContractType = vendorDto.ContractType;
        
        var updatedVendor = await _vendorRepository.UpdateAsync(vendor);
        
        return _mapper.Map<VendorDto>(updatedVendor);
    }
    
    public async Task<VendorDto> DeleteVendor(Guid petId)
    {
        var vendor = await _vendorRepository.GetByIdAsync(petId);
        
        if (vendor == null)
        {
            throw new KeyNotFoundException($"Vendor with id '{petId}' was not found");
        }
        
        var deletedVendor = await _vendorRepository.DeleteAsync(vendor);
        
        return _mapper.Map<VendorDto>(deletedVendor);
    }
    
    public async Task<IEnumerable<VendorDto>> GetVendorsByContractType(ContractType type)
    {
        var vendors = await _vendorRepository.GetVendorsByContractType(type);
        
        return _mapper.Map<IEnumerable<VendorDto>>(vendors);
    }
    
    public async Task<IEnumerable<HealthCareDto>> GetVendorHealthCareRecords(Guid vendorId)
    {
        var healthCareRecords = await _vendorRepository.GetVendorHealthCareRecords(vendorId);
        
        return _mapper.Map<IEnumerable<HealthCareDto>>(healthCareRecords);
    }
}