using Microsoft.EntityFrameworkCore;
using DAL_Core;
using DAL_Core.Entities;
using DAL_Core.Enums;
using PetDAL.Repositories.Interfaces;

namespace PetDAL.Repositories;

public class PetRepository : Repository<Pet>, IPetRepository
{
    private readonly PetStoreDbContext _context;
    
    public PetRepository(PetStoreDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Pet>> GetPetsByStoreAsync(Guid storeId)
    {
        return await _context.Pets
            .Where(p => p.StoreId == storeId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Pet>> GetPetsByTypeAsync(PetTypes type)
    {
        return await _context.Pets
            .Where(p => p.Type == type)
            .ToListAsync();
    }
}