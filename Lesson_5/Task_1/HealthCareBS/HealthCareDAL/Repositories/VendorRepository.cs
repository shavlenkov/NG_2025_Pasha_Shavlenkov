using DAL_Core;
using DAL_Core.Entities;
using HealthCareDAL.Repositories.Interfaces;

namespace HealthCareDAL.Repositories;

public class VendorRepository: Repository<Vendor>, IVendorRepository
{
    public VendorRepository(PetStoreDbContext context) : base(context)
    {
    }
}