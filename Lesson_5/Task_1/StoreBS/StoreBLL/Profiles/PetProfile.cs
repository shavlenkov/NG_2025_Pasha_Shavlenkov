using AutoMapper;
using DAL_Core.Entities;
using StoreBLL.Models;

namespace StoreBLL.Profiles;

public class PetProfile : Profile
{
    public PetProfile()
    {
        CreateMap<Pet, PetDto>();
        CreateMap<PetDto, Pet>();
    }
}