using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/votes")]
public class VoteController : ControllerBase
{
    private readonly IVoteService _voteService;
    
    public VoteController(IVoteService voteService)
    {
        _voteService = voteService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var votes = await _voteService.GetAllAsync();
        
        return Ok(votes);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var vote = await _voteService.GetByIdAsync(id);
            
            return Ok(vote);
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
    public async Task<IActionResult> Create([FromBody] VoteModel voteModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var createdVote = await _voteService.CreateAsync(voteModel);
            
            return Ok(createdVote);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] VoteModel voteModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var updatedVote = await _voteService.UpdateAsync(id, voteModel);
            
            return Ok(updatedVote);
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
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var deletedVote = await _voteService.DeleteAsync(id);
            
            return Ok(new { deletedVote.Id });
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