using Microsoft.AspNetCore.Mvc;
using StoreBLL.Services.Interfaces;
using StoreBLL.Models;

namespace StoreBS.Controllers;

[Route("api/stores")]
[ApiController]
public class StoreController : Controller
{
    private readonly IStoreService _storeService;
    
    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllStores()
    {
        try
        {
            var stores = await _storeService.GetAllStores();
            
            return Ok(stores);
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStoreById(Guid id)
    {
        try
        {
            var store = await _storeService.GetStoreById(id);
            
            return Ok(store);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStore(Guid id, [FromBody] StoreDto dto)
    {
        try
        {
            var updatedStore = await _storeService.UpdateStore(id, dto);
            
            return Ok(updatedStore);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("{storeId}/pets")]
    public async Task<IActionResult> GetStorePets(Guid storeId)
    {
        try
        {
            var pets = await _storeService.GetStorePets(storeId);
            
            return Ok(pets);
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("{storeId}/healthcares")]
    public async Task<IActionResult> GetStoreHealthCareRecords(Guid storeId)
    {
        try
        {
            var healthCareRecords = await _storeService.GetStoreHealthCareRecords(storeId);
            
            return Ok(healthCareRecords);
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
}