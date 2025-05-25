using Microsoft.EntityFrameworkCore;
using DAL_Core;
using DAL_Core.Entities;
using HealthCareDAL.Repositories.Interfaces;

namespace HealthCareDAL.Repositories;

public class HealthCareRepository : Repository<HealthCare>, IHealthCareRepository
{
    private readonly PetStoreDbContext _context;
    
    public HealthCareRepository(PetStoreDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<HealthCare>> GetHealthCareRecordsByPet(Guid petId)
    {
        return await _context.HealthCares
            .Where(h => h.PetId == petId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<HealthCare>> GetHealthCareRecordsByVendor(Guid vendorId)
    {
        return await _context.HealthCares
            .Where(h => h.VendorId == vendorId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<HealthCare>> GetExpiringHealthCareRecords()
    {
        return await _context.HealthCares
            .Where(h => h.ExpirationDate >= DateTime.UtcNow)
            .ToListAsync();
    }
}