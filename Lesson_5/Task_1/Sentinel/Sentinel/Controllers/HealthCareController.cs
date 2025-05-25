using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Net;
using SentinelBusinessLayer.Services.Interfaces;
using SentinelBusinessLayer.Models;

namespace Sentinel.Controllers;

[Route("api/healthcares")]
[ApiController]
public class HealthCareController : Controller
{
    private readonly IHealthCareService _healthCareService;
    
    public HealthCareController(IHealthCareService healthCareService)
    {
        _healthCareService = healthCareService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllHealthCares()
    {
        try
        {
            var healthCareRecords = await _healthCareService.GetAllHealthCareRecords();
            
            return Ok(healthCareRecords);
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHealthCareById(Guid id)
    {
        try
        {
            var healthCareRecord = await _healthCareService.GetHealthCareById(id);
            
            return Ok(healthCareRecord);
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
    public async Task<IActionResult> AddHealthCareRecord([FromBody] HealthCareDto healthCareDto)
    {
        try
        {
            var addedHealthCareRecord = await _healthCareService.AddHealthCareRecord(healthCareDto);
            
            return Ok(addedHealthCareRecord);
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
    public async Task<IActionResult> UpdateHealthCareRecord(Guid id, [FromBody] HealthCareDto dto)
    {
        try
        {
            var updatedHealthCareRecord = await _healthCareService.UpdateHealthCareRecord(id, dto);
            
            return Ok(updatedHealthCareRecord);
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
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHealthCareRecord(Guid id)
    {
        try
        {
            var deletedHealthCareRecord = await _healthCareService.DeleteHealthCareRecord(id);
            
            return Ok(deletedHealthCareRecord);
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
    
    [HttpGet("by-pet/{petId}")]
    public async Task<IActionResult> GetHealthCareRecordsByPet(Guid petId)
    {
        try
        {
            var healthCareRecords = await _healthCareService.GetHealthCareRecordsByPet(petId);
            
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
    
    [HttpGet("by-vendor/{vendorId}")]
    public async Task<IActionResult> GetHealthCareRecordsByVendor(Guid vendorId)
    {
        try
        {
            var healthCareRecords = await _healthCareService.GetHealthCareRecordsByPet(vendorId);
            
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
    
    [HttpGet("expiring")]
    public async Task<IActionResult> GetExpiringHealthCareRecords()
    {
        try
        {
            var healthCareRecords = await _healthCareService.GetExpiringHealthCareRecords();
            
            return Ok(healthCareRecords);
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
}
