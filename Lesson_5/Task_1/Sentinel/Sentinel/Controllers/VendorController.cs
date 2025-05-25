using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Net;
using DAL_Core.Enums;
using SentinelBusinessLayer.Services.Interfaces;
using SentinelBusinessLayer.Models;

namespace Sentinel.Controllers;

[Route("api/vendors")]
[ApiController]
public class VendorController : Controller
{
    private readonly IVendorService _vendorService;
    
    public VendorController(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllVendors()
    {
        try
        {
            var vendors = await _vendorService.GetAllVendors();
            
            return Ok(vendors);
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVendorById(Guid id)
    {
        try
        {
            var vendor = await _vendorService.GetVendorById(id);
            
            return Ok(vendor);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddVendor([FromBody] VendorDto vendorDto)
    {
        try
        {
            var addedVendor = await _vendorService.AddVendor(vendorDto);
            
            return Ok(addedVendor);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVendor(Guid id, [FromBody] VendorDto vendorDto)
    {
        try
        {
            var updatedVendor = await _vendorService.UpdateVendor(id, vendorDto);
            
            return Ok(updatedVendor);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.BadRequest)
        {
            return BadRequest(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVendor(Guid id)
    {
        try
        {
            var deletedVendor = await _vendorService.DeleteVendor(id);
            
            return Ok(deletedVendor);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpGet("/{contractType}/contract-type")]
    public async Task<IActionResult> GetVendorsByContractType(ContractType contractType)
    {
        try
        {
            var vendors = await _vendorService.GetVendorsByContractType(contractType);
            
            return Ok(vendors);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpGet("/{id}/healthcares")]
    public async Task<IActionResult> GetVendorHealthCareRecords(Guid vendorId)
    {
        try
        {
            var healthCareRecords = await _vendorService.GetVendorHealthCareRecords(vendorId);
            
            return Ok(healthCareRecords);
        }
        catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
}
