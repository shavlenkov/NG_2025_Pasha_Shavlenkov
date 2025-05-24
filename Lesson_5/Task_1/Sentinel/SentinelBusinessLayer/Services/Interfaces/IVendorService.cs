using DAL_Core.Enums;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Services.Interfaces;

public interface IVendorService
{
    Task<IEnumerable<VendorDto>> GetAllVendors();
    Task<VendorDto> GetVendorById(Guid id);
    Task<VendorDto> AddVendor(VendorDto vendorDto);
    Task<VendorDto> UpdateVendor(Guid id, VendorDto vendorDto);
    Task<IEnumerable<VendorDto>> GetVendorsByContractType(ContractType type);
    Task<IEnumerable<HealthCareDto>> GetVendorHealthCareRecords(Guid vendorId);
    Task<VendorDto> DeleteVendor(Guid id);
}