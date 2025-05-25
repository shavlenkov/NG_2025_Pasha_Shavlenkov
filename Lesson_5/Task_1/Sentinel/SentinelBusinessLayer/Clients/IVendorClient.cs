using Refit;
using DAL_Core.Enums;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Clients
{
    public interface IVendorClient
    {
        [Get("/api/vendors")]
        Task<IEnumerable<VendorDto>> GetAllVendors();
        
        [Get("/api/vendors/{id}")]
        Task<VendorDto> GetVendorById(Guid id);
        
        [Post("/api/vendors")]
        Task<VendorDto> AddVendor([Body] VendorDto vendorDto);
        
        [Put("/api/vendors/{id}")]
        Task<VendorDto> UpdateVendor(Guid id, [Body] VendorDto vendorDto);
        
        [Delete("/api/vendors/{id}")]
        Task<VendorDto> DeleteVendor(Guid id);
        
        [Get("/api/vendors/{contractType}/contract-type")]
        Task<IEnumerable<VendorDto>> GetVendorsByContractType(ContractType contractType);
        
        [Get("/api/vendors/{id}/healthcares")]
        Task<IEnumerable<HealthCareDto>> GetVendorHealthCareRecords(Guid id);
    }
}