using AutoMapper;
using DAL_Core.Entities;
using VendorBLL.Models;

namespace VendorBLL.Profiles;

public class HealthCareProfile : Profile
{
    public HealthCareProfile()
    {
        CreateMap<HealthCare, HealthCareDto>();
        CreateMap<HealthCareDto, HealthCare>();
    }
}