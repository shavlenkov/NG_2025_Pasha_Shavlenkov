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
        var comment = await _commentService.GetByIdAsync(id);

        return comment == null ? NotFound() : Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CommentModel commentModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdComment = await _commentService.CreateAsync(commentModel);

        return Ok(createdComment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CommentModel commentModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedComment = await _commentService.UpdateAsync(id, commentModel);

        return updatedComment == null ? NotFound() : Ok(updatedComment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deletedComment = await _commentService.DeleteAsync(id);

        return deletedComment == null ? NotFound() : Ok(new { id = deletedComment.Id });
    }
}