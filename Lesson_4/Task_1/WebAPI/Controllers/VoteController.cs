using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/votes")]
public class VoteController : Controller
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
        var vote = await _voteService.GetByIdAsync(id);
        
        return vote == null ? NotFound() : Ok(vote);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VoteModel voteModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdVote = await _voteService.CreateAsync(voteModel);
        
        return Ok(createdVote);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] VoteModel voteModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedVote = await _voteService.UpdateAsync(id, voteModel);
        
        return updatedVote == null ? NotFound() : Ok(updatedVote);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deletedVote = await _voteService.DeleteAsync(id);
        
        return deletedVote == null ? NotFound() : Ok(new { id = deletedVote.Id });
    }
}