using Refit;
using DAL_Core.Enums;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Clients;

public interface IPetClient
{
    [Get("/api/pets")]
    Task<IEnumerable<PetDto>> GetAllPets();
    
    [Get("/api/pets/{id}")]
    Task<PetDto> GetPetById(Guid id);
    
    [Post("/api/pets")]
    Task<PetDto> AddPet(PetDto petDto);
    
    [Put("/api/pets/{id}")]
    Task<PetDto> UpdatePet(Guid id, PetDto petDto);
    
    [Get("/api/pets/by-store/{id}")]
    Task<PetDto> GetPetsByStore(Guid id);
    
    [Get("/api/pets/by-type/{type}")]
    Task<PetDto> GetPetsByType(PetTypes type);
    
    [Delete("/api/pets/{id}")]
    Task<PetDto> AdoptPet(Guid id);
}