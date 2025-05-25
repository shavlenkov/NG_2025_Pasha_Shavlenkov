using DAL_Core.Entities;

namespace StoreDAL.Repositories.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T> UpdateAsync(T entity);
}