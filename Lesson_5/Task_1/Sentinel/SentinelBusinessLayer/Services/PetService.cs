using DAL_Core.Enums;
using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Services.Interfaces;

namespace SentinelBusinessLayer.Services;

public class PetService: IPetService
{
    private readonly IPetClient _petClient;
    
    public PetService(IPetClient petClient)
    {
        _petClient = petClient;
    }
    
    public async Task<IEnumerable<PetDto>> GetAllPets() => 
        await _petClient.GetAllPets();
    
    public async Task<PetDto> GetPetById(Guid id) => 
        await _petClient.GetPetById(id);
    
    public async Task<PetDto> AddPet(PetDto petDto) => 
        await _petClient.AddPet(petDto);
    
    public async Task<PetDto> UpdatePet(Guid id, PetDto petDto) => 
        await _petClient.UpdatePet(id, petDto);
    
    public async Task<PetDto> GetPetsByStore(Guid storeId) => 
        await _petClient.GetPetsByStore(storeId);
    
    public async Task<PetDto> GetPetsByType(PetTypes type) =>
        await _petClient.GetPetsByType(type);
    
    public async Task<PetDto> AdoptPet(Guid id) => 
        await _petClient.AdoptPet(id);
}