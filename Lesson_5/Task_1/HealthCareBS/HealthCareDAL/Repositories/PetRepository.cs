using DAL_Core;
using DAL_Core.Entities;
using HealthCareDAL.Repositories.Interfaces;

namespace HealthCareDAL.Repositories;

public class PetRepository: Repository<Pet>, IPetRepository
{
    public PetRepository(PetStoreDbContext context) : base(context)
    {
    }
}