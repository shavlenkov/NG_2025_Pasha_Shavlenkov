using Microsoft.EntityFrameworkCore;
using DAL_Core;
using DAL_Core.Enums;
using DAL_Core.Entities;
using VendorDAL.Repositories.Interfaces;

namespace VendorDAL.Repositories;

public class VendorRepository: Repository<Vendor>, IVendorRepository
{
    private readonly PetStoreDbContext _context;
    
    public VendorRepository(PetStoreDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Vendor>> GetVendorsByContractType(ContractType type)
    {
        return await _context.Vendors
            .Where(v => v.ContractType == type)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<HealthCare>> GetVendorHealthCareRecords(Guid vendorId)
    {
        return await _context.HealthCares
            .Where(h => h.VendorId == vendorId)
            .ToListAsync();
    }
}