using DAL_Core.Enums;
using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Services.Interfaces;

namespace SentinelBusinessLayer.Services;

public class VendorService : IVendorService
{
    private readonly IVendorClient _vendorClient;
    
    public VendorService(IVendorClient vendorClient)
    {
        _vendorClient = vendorClient;
    }
    
    public async Task<IEnumerable<VendorDto>> GetAllVendors() => 
        await _vendorClient.GetAllVendors();
    
    public async Task<VendorDto> GetVendorById(Guid id) => 
        await _vendorClient.GetVendorById(id);
    
    public async Task<VendorDto> AddVendor(VendorDto vendorDto) => 
        await _vendorClient.AddVendor(vendorDto);
    
    public async Task<VendorDto> UpdateVendor(Guid id, VendorDto vendorDto) =>
        await _vendorClient.UpdateVendor(id, vendorDto);
    
    public async Task<IEnumerable<VendorDto>> GetVendorsByContractType(ContractType type) => 
        await _vendorClient.GetVendorsByContractType(type);
    
    public async Task<IEnumerable<HealthCareDto>> GetVendorHealthCareRecords(Guid vendorId) => 
        await _vendorClient.GetVendorHealthCareRecords(vendorId);
    
    public async Task<VendorDto> DeleteVendor(Guid id) =>
        await _vendorClient.DeleteVendor(id);
}