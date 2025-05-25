using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Net;
using SentinelBusinessLayer.Services.Interfaces;
using SentinelBusinessLayer.Models;

namespace Sentinel.Controllers;

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
        catch (Exception ex)
        {
            return StatusCode(500, new { ErrorMessage = ex.Message });
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
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStore(Guid id, [FromBody] StoreDto storeDto)
    {
        try
        {
            var updatedStore = await _storeService.UpdateStore(id, storeDto);
            
            return Ok(updatedStore);
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
    
    [HttpGet("{storeId}/pets")]
    public async Task<IActionResult> GetStorePets(Guid storeId)
    {
        try
        {
            var pets = await _storeService.GetStorePets(storeId);
            
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
    
    [HttpGet("{storeId}/healthcares")]
    public async Task<IActionResult> GetStoreHealthcareRecords(Guid storeId)
    {
        try
        {
            var healthCareRecords = await _storeService.GetStoreHealthcareRecords(storeId);
            
            return Ok(healthCareRecords);
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
