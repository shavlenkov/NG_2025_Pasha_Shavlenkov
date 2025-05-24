using DAL_Core.Enums;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Services.Interfaces;

public interface IPetService
{
    Task<IEnumerable<PetDto>> GetAllPets();
    Task<PetDto> GetPetById(Guid id);
    Task<PetDto> AddPet(PetDto petDto);
    Task<PetDto> UpdatePet(Guid id, PetDto petDto);
    Task<PetDto> GetPetsByStore(Guid id);
    Task<PetDto> GetPetsByType(PetTypes type);
    Task<PetDto> AdoptPet(Guid id);
}