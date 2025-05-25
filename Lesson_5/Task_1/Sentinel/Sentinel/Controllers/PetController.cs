using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Net;
using DAL_Core.Enums;
using SentinelBusinessLayer.Services.Interfaces;
using SentinelBusinessLayer.Models;

namespace Sentinel.Controllers;

[Route("api/pets")]
[ApiController]
public class PetController : Controller
{
    private readonly IPetService _petService;
    
    public PetController(IPetService petService)
    {
        _petService = petService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPets()
    {
        try
        {
            var pets = await _petService.GetAllPets();
            
            return Ok(pets);
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPetById(Guid id)
    {
        try
        {
            var pet = await _petService.GetPetById(id);
            
            return Ok(pet);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPet([FromBody] PetDto petDto)
    {
        try
        {
            var addedPet = await _petService.AddPet(petDto);
            
            return Ok(addedPet);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.BadRequest)
        {
            return BadRequest(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePet(Guid id, [FromBody] PetDto petDto)
    {
        try
        {
            var updatedPet = await _petService.UpdatePet(id, petDto);
            
            return Ok(updatedPet);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.BadRequest)
        {
            return BadRequest(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("by-store/{storeId}")]
    public async Task<IActionResult> GetPetsByStore(Guid storeId)
    {
        try
        {
            var pets = await _petService.GetPetsByStore(storeId);
            
            return Ok(pets);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("by-type/{type}")]
    public async Task<IActionResult> GetPetsByType(PetTypes type)
    {
        try
        {
            var pets = await _petService.GetPetsByType(type);
            
            return Ok(pets);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpDelete("{petId}/adopt")]
    public async Task<IActionResult> AdoptPet(Guid petId)
    {
        try
        {
            var adoptedPet = await _petService.AdoptPet(petId);
            
            return Ok(adoptedPet);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
}