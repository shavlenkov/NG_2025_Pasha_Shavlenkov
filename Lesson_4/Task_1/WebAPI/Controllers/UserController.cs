using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            
            return Ok(user);
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
    public async Task<IActionResult> Create([FromBody] UserModel userModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var createdUser = await _userService.CreateAsync(userModel);
            
            return Ok(createdUser);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] UserModel userModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var updatedUser = await _userService.UpdateAsync(id, userModel);
            
            return Ok(updatedUser);
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
            var deletedUser = await _userService.DeleteAsync(id);
            
            return Ok(new { deletedUser.Id });
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
