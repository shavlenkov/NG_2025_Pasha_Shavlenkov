using AutoMapper;
using DAL_Core.Entities;
using PetBLL.Models;

namespace PetBLL.Profiles;

public class PetProfile : Profile
{
    public PetProfile()
    {
        CreateMap<Pet, PetDto>();
        CreateMap<PetDto, Pet>();
    }
}