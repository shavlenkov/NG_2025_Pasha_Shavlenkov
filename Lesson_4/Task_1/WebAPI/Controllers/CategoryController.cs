using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();
        
        return Ok(categories);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var category = await _categoryService.GetByIdAsync(id);
            
            return Ok(category);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryModel categoryModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var createdCategory = await _categoryService.CreateAsync(categoryModel);
            
            return Ok(createdCategory);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CategoryModel categoryModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var updatedCategory = await _categoryService.UpdateAsync(id, categoryModel);
            
            return Ok(updatedCategory);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var deletedCategory = await _categoryService.DeleteAsync(id);
            
            return Ok(new { deletedCategory.Id });
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
}
