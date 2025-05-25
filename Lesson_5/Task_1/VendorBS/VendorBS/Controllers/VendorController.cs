using Microsoft.AspNetCore.Mvc;
using DAL_Core.Enums;
using VendorBLL.Services.Interfaces;
using VendorBLL.Models;

namespace VendorBS.Controllers;

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
            return StatusCode(500, new { ErrorMessage = exception.Message });
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
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
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
        catch (InvalidOperationException exception)
        {
            return BadRequest(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
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
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVendor(Guid id)
    {
        try
        {
            var deletedVendor = await _vendorService.DeleteVendor(id);
            
            return Ok(deletedVendor);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("{contractType}/contract-type")]
    public async Task<IActionResult> GetVendorsByContractType(ContractType contractType)
    {
        try
        {
            var vendors = await _vendorService.GetVendorsByContractType(contractType);
            
            return Ok(vendors);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("{id}/healthcares")]
    public async Task<IActionResult> GetVendorHealthCareRecords(Guid vendorId)
    {
        try
        {
            var healthCareRecords = await _vendorService.GetVendorHealthCareRecords(vendorId);
            
            return Ok(healthCareRecords);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
}
