using Microsoft.AspNetCore.Mvc;
using HealthCareBLL.Services.Interfaces;
using HealthCareBLL.Models;

namespace HealthCareBS.Controllers;

[Route("api/healthcares")]
[ApiController]
public class HealthCareController : ControllerBase
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
            var healthCareRecords= await _healthCareService.GetAllHealthCareRecords();
            
            return Ok(healthCareRecords);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetHealthCareById(Guid id)
    {
        try
        {
            var healthCareRecord = await _healthCareService.GetHealthCareRecordById(id);
            
            return Ok(healthCareRecord);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddHealthCareRecord([FromBody] HealthCareDto dto)
    {
        try
        {
            var addedHealthCareRecord = await _healthCareService.AddHealthCareRecord(dto);
            
            return Ok(addedHealthCareRecord);
        }
        catch (InvalidOperationException ex)
        {
            return UnprocessableEntity(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
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
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return UnprocessableEntity(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
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
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
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
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("by-vendor/{vendorId}")]
    public async Task<IActionResult> GetHealthCareRecordsByVendor(Guid vendorId)
    {
        try
        {
            var healthCareRecords = await _healthCareService.GetHealthCareRecordsByVendor(vendorId);
            
            return Ok(healthCareRecords);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("expiring")]
    public async Task<IActionResult> GetExpiringHealthCareRecords()
    {
        try
        {
            var records = await _healthCareService.GetExpiringHealthCareRecords();
            
            return Ok(records);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
