using DAL_Core.Entities;
using DAL_Core.Enums;

namespace PetDAL.Repositories.Interfaces;

public interface IPetRepository : IRepository<Pet>
{
    Task<IEnumerable<Pet>> GetPetsByStoreAsync(Guid storeId);
    Task<IEnumerable<Pet>> GetPetsByTypeAsync(PetTypes type);
}