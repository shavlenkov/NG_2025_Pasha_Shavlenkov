using Microsoft.EntityFrameworkCore;
using DAL_Core;
using DAL_Core.Entities;
using StoreDAL.Repositories.Interfaces;

namespace StoreDAL.Repositories;

public class StoreRepository : Repository<Store>, IStoreRepository
{
    private readonly PetStoreDbContext _context;
    
    public StoreRepository(PetStoreDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Pet>> GetStorePetsAsync(Guid storeId)
    {
        return await _context.Pets
            .Where(p => p.StoreId == storeId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<HealthCare>> GetStoreHealthCaresRecordsAsync(Guid storeId)
    {
        return await _context.HealthCares
            .Include(h => h.Pet)
            .Include(h => h.Vendor)
            .Where(h => h.Pet.StoreId == storeId)
            .ToListAsync();
    }
}