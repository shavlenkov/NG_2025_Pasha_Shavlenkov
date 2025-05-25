using DAL_Core.Enums;
using PetBLL.Models;

namespace PetBLL.Services.Interfaces;

public interface IPetService
{
    Task<IEnumerable<PetDto>> GetAllPets();
    Task<PetDto> GetPetById(Guid id);
    Task<IEnumerable<PetDto>> GetPetsByStore(Guid storeId);
    Task<IEnumerable<PetDto>> GetPetsByType(PetTypes type);
    Task<PetDto> AddPet(PetDto petDto);
    Task<PetDto> UpdatePet(Guid id, PetDto petDto);
    Task<PetDto> AdoptPet(Guid petId);
}