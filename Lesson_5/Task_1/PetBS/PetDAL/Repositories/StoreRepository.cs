using DAL_Core;
using DAL_Core.Entities;
using PetDAL.Repositories.Interfaces;

namespace PetDAL.Repositories;

public class StoreRepository : Repository<Store>, IStoreRepository
{
    public StoreRepository(PetStoreDbContext context) : base(context)
    {
    }
}