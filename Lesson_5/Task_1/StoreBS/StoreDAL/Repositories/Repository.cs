using Microsoft.EntityFrameworkCore;
using DAL_Core;
using DAL_Core.Entities;
using StoreDAL.Repositories.Interfaces;

namespace StoreDAL.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly PetStoreDbContext _context;
    private readonly DbSet<T> _dbSet;
    
    public Repository(PetStoreDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }
}