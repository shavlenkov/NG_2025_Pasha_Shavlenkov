using AutoMapper;
using DAL_Core.Entities;
using HealthCareBLL.Models;

namespace HealthCareBLL.Profiles;

public class HealthCareProfile : Profile
{
    public HealthCareProfile()
    {
        CreateMap<HealthCare, HealthCareDto>();
        CreateMap<HealthCareDto, HealthCare>();
    }
}