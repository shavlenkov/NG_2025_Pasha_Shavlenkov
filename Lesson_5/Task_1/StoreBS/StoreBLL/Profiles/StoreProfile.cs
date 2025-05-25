using AutoMapper;
using DAL_Core.Entities;
using StoreBLL.Models;

namespace StoreBLL.Profiles;

public class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<Store, StoreDto>();
        CreateMap<StoreDto, Store>();
    }
}