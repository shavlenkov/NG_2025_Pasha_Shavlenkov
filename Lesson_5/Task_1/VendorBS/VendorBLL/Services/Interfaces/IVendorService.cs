using VendorBLL.Models;
using DAL_Core.Enums;

namespace VendorBLL.Services.Interfaces;

public interface IVendorService
{
    Task<IEnumerable<VendorDto>> GetAllVendors();
    Task<VendorDto> GetVendorById(Guid id);
    Task<VendorDto> AddVendor(VendorDto petDto);
    Task<VendorDto> UpdateVendor(Guid id, VendorDto vendorDto);
    Task<VendorDto> DeleteVendor(Guid id);
    Task<IEnumerable<VendorDto>> GetVendorsByContractType(ContractType type);
    Task<IEnumerable<HealthCareDto>> GetVendorHealthCareRecords(Guid vendorId);
}