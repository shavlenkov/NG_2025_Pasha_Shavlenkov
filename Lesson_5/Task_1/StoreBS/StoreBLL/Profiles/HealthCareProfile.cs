using AutoMapper;
using DAL_Core.Entities;
using StoreBLL.Models;

namespace StoreBLL.Profiles;

public class HealthCareProfile : Profile
{
    public HealthCareProfile()
    {
        CreateMap<HealthCare, HealthCareDto>();
        CreateMap<HealthCareDto, HealthCare>();
    }
}