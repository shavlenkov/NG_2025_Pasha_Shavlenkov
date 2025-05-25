using DAL_Core.Entities;

namespace StoreDAL.Repositories.Interfaces;

public interface IStoreRepository: IRepository<Store>
{
    Task<IEnumerable<Pet>> GetStorePetsAsync(Guid storeId);
    Task<IEnumerable<HealthCare>> GetStoreHealthCaresRecordsAsync(Guid storeId);
}