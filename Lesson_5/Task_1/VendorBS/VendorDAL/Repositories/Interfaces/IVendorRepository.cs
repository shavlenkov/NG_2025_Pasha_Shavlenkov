using DAL_Core.Entities;
using DAL_Core.Enums;

namespace VendorDAL.Repositories.Interfaces;

public interface IVendorRepository: IRepository<Vendor>
{
    Task<IEnumerable<Vendor>> GetVendorsByContractType(ContractType type);
    Task<IEnumerable<HealthCare>> GetVendorHealthCareRecords(Guid vendorId);
}