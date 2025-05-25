using DAL_Core.Entities;

namespace HealthCareDAL.Repositories.Interfaces;

public interface IHealthCareRepository : IRepository<HealthCare>
{
    Task<IEnumerable<HealthCare>> GetHealthCareRecordsByPet(Guid petId);
    Task<IEnumerable<HealthCare>> GetHealthCareRecordsByVendor(Guid vendorId);
    Task<IEnumerable<HealthCare>> GetExpiringHealthCareRecords();
}