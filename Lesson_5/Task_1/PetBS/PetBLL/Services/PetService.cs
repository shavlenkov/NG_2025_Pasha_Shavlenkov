using AutoMapper;
using DAL_Core.Entities;
using DAL_Core.Enums;
using PetDAL.Repositories.Interfaces;
using PetBLL.Services.Interfaces;
using PetBLL.Models;

namespace PetBLL.Services;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    
    public PetService(
        IPetRepository petRepository,
        IStoreRepository storeRepository,
        IMapper mapper)
    {
        _petRepository = petRepository;
        _storeRepository = storeRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<PetDto>> GetAllPets()
    {
        var pets = await _petRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<PetDto>>(pets);
    }
    
    public async Task<PetDto> GetPetById(Guid id)
    {
        var pet = await _petRepository.GetByIdAsync(id);
        
        if (pet == null)
        {
            throw new KeyNotFoundException($"Pet with id '{id}' not found");
        }
        
        return _mapper.Map<PetDto>(pet);
    }
    
    public async Task<PetDto> AddPet(PetDto petDto)
    {
        if (await _storeRepository.GetByIdAsync(petDto.StoreId) != null)
        {
            throw new InvalidOperationException($"Store with id '{petDto.StoreId}' does not exist");
        }
        
        var pet = _mapper.Map<Pet>(petDto);
        
        var addedPet = await _petRepository.AddAsync(pet);
        
        return _mapper.Map<PetDto>(addedPet);
    }
    
    public async Task<PetDto> UpdatePet(Guid id, PetDto petDto)
    {
        var pet = await _petRepository.GetByIdAsync(id);
        
        if (pet == null)
        {
            throw new KeyNotFoundException($"Pet with id '{id}' was not found");
        }
        
        if (await _storeRepository.GetByIdAsync(petDto.StoreId) != null)
        {
            throw new InvalidOperationException($"Store with id '{petDto.StoreId}' does not exist");
        }
        
        pet.Name = petDto.Name;
        pet.Type = petDto.Type;
        pet.Breed = petDto.Breed;
        pet.StoreId = petDto.StoreId;
        
        var updatedPet = await _petRepository.UpdateAsync(pet);
        
        return _mapper.Map<PetDto>(updatedPet);
    }
    
    public async Task<IEnumerable<PetDto>> GetPetsByStore(Guid storeId)
    {
        var pets = await _petRepository.GetPetsByStoreAsync(storeId);
        
        if (await _storeRepository.GetByIdAsync(storeId) == null)
        {
            throw new InvalidOperationException($"Store with id '{storeId}' does not exist");
        }
        
        return _mapper.Map<IEnumerable<PetDto>>(pets);
    }
    
    public async Task<IEnumerable<PetDto>> GetPetsByType(PetTypes type)
    {
        var pets = await _petRepository.GetPetsByTypeAsync(type);
        
        return _mapper.Map<IEnumerable<PetDto>>(pets);
    }
    
    public async Task<PetDto> AdoptPet(Guid petId)
    {
        var pet = await _petRepository.GetByIdAsync(petId);
        
        if (pet == null)
        {
            throw new KeyNotFoundException($"Pet with id '{petId}' was not found");
        }
        
        var adoptedPet = await _petRepository.DeleteAsync(pet);
        
        return _mapper.Map<PetDto>(adoptedPet);
    }
}