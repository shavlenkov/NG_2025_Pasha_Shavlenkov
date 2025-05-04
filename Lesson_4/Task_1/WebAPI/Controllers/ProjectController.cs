using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectController : Controller
{
    private readonly IProjectService _projectService;
    
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllAsync();
        
        return Ok(projects);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var project = await _projectService.GetByIdAsync(id);
            
            return Ok(project);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (InvalidOperationException exception)
        {
            return UnprocessableEntity(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProjectModel projectModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var createdProject = await _projectService.CreateAsync(projectModel);
            
            return Ok(createdProject);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (InvalidOperationException exception)
        {
            return UnprocessableEntity(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProjectModel projectModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var updatedProject = await _projectService.UpdateAsync(id, projectModel);
            
            return Ok(updatedProject);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { error = exception.Message });
        }
        catch (InvalidOperationException exception)
        {
            return UnprocessableEntity(new { Error = exception.Message });
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
            var deletedProject = await _projectService.DeleteAsync(id);
            
            return Ok(new { deletedProject.Id });
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { Error = exception.Message });
        }
        catch (InvalidOperationException exception)
        {
            return UnprocessableEntity(new { Error = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
}
