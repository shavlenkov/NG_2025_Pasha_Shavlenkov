using Microsoft.AspNetCore.Mvc;
using SentinelBusinessLayer.Services.Interfaces;
using SentinelBusinessLayer.Models;
using Refit;
using System.Net;

namespace Sentinel.Controllers;

[Route("api/stores")]
[ApiController]
public class StoreController : ControllerBase
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
            return StatusCode(500, new { Error = ex.Message });
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
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
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
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.UnprocessableEntity)
        {
            return UnprocessableEntity(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
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
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }

    [HttpGet("{storeId}/healthcares")]
    public async Task<IActionResult> GetStoreHealthcareRecords(Guid storeId)
    {
        try
        {
            var healthcares = await _storeService.GetStoreHealthcareRecords(storeId);
            
            return Ok(healthcares);
        }
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }
}
