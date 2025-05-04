using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/comments")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;
    
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentService.GetAllAsync();
        
        return Ok(comments);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var comment = await _commentService.GetByIdAsync(id);
            
            return Ok(comment);
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
    public async Task<IActionResult> Create([FromBody] CommentModel commentModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var createdComment = await _commentService.CreateAsync(commentModel);
            
            return Ok(createdComment);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] CommentModel commentModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var updatedComment = await _commentService.UpdateAsync(id, commentModel);
            
            return Ok(updatedComment);
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
            var deletedComment = await _commentService.DeleteAsync(id);
            
            return Ok(new { deletedComment.Id });
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
