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
    public async Task<IActionResult> GetAllProjects()
    {
        try
        {
            var projects = await _projectService.GetAllProjects();
            
            return Ok(projects);
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { Error = exception.Message });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectById(Guid id)
    {
        try
        {
            var project = await _projectService.GetProjectById(id);
            
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
    public async Task<IActionResult> AddProject([FromBody] ProjectModel projectModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var addedProject = await _projectService.AddProject(projectModel);
            
            return Ok(addedProject);
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
    public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectModel projectModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var updatedProject = await _projectService.UpdateProject(id, projectModel);
            
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
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        try
        {
            var deletedProject = await _projectService.DeleteProject(id);
            
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
